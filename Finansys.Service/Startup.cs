using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Finansys.Aplicacao.Interfaces;
using MediatR;
using Finansys.CrossCutting.DependencyInjection;
using System.Net.Http;
using System.Net;
using System.IO;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Finansys.Service
{
    public class Startup
    {
        // public Startup(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }






        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            ConfigureFabrica.ConfigureDependencyFabrica(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            services.AddMediatR(typeof(ICategoriaRepositorio).Assembly);
            //configurar crosscutting
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Finansys.Service", Version = "v1" });
            });

            Task task = GetJwtks();
            task.Wait();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
                        {
                            var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(JwtksCache).Keys;
                            return (IEnumerable<SecurityKey>)keys;
                        },

                        ValidIssuer = Configuration["Authentication:Cognito:Issuer"],
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidAudience = Configuration["Authentication:Cognito:ClientId"],
                        ValidateAudience = false,
                        NameClaimType = "cognito:username"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finansys.Service v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public string JwtksCache { get; set; }


        private async Task GetJwtks()
        {
            String cacheFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache", "CacheJwks.json");
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache"));
            if (File.Exists(cacheFilePath) == false)
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (requestMessage, certificate, chain, sslErrors) => true
                };
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var client = new HttpClient(handler);
                HttpResponseMessage message = await client.GetAsync(Configuration["Authentication:Cognito:JwksUri"]);
                String messageText = await message.Content.ReadAsStringAsync();
                File.WriteAllText(cacheFilePath, messageText);
                JwtksCache = messageText;

            }
            else
            {
                JwtksCache = File.ReadAllText(cacheFilePath);
            }
        }
    }
}
