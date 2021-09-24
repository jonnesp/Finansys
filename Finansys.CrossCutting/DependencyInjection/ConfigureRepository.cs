using Finansys.Data.Repository.Repositorios;
using System;
using Finansys.Aplicacao.Interfaces;
using Finansys.Data.Repository.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Finansys.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            var stringDeConexao = "Server = localhost; Port = 3306; Database = Fynansys; Uid = root; Pwd = mudar@123";
            var sqlServerVersion = new MySqlServerVersion(new Version(10, 4, 17));
            serviceCollection.AddDbContext<Context>(options => options.UseMySql(stringDeConexao, sqlServerVersion));
            serviceCollection.AddScoped(typeof(ICategoriaRepositorio), typeof(CategoriaRepositorio));
            serviceCollection.AddScoped(typeof(ILancamentoRepositorio), typeof(LancamentoRepositorio));
            serviceCollection.AddScoped(typeof(IControleOrcamentario), typeof(ControleOrcamentarioRepositorio));
            serviceCollection.AddScoped(typeof(ICategoriaOrcamentoRepositorio), typeof(CategoriaOrcamentoRepositorio));
        }
    }
}
