using Finansys.Dominio.Fabricas;
using Microsoft.Extensions.DependencyInjection;

namespace Finansys.CrossCutting.DependencyInjection
{
    public class ConfigureFabrica
    {

        public static void ConfigureDependencyFabrica(IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient<ICategoriaFabrica, CategoriaFabrica>();
            serviceCollection.AddTransient<ILancamentoFabrica, LancamentoFabrica>();

        }


    }
}
