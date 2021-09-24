using Finansys.Dominio.Fabricas;
using Microsoft.Extensions.DependencyInjection;

namespace Finansys.CrossCutting.DependencyInjection
{
    public class ConfigureFabrica
    {

        public static void ConfigureDependencyFabrica(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<ICategoriaFabrica, CategoriaFabrica>();
            serviceCollection.AddScoped<ILancamentoFabrica, LancamentoFabrica>();
            serviceCollection.AddScoped<ICategoriaOrcamentoFabrica, CategoriaOrcamentoFabrica>();
        }


    }
}
