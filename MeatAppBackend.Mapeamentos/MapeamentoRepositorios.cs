using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Repositorios.Restaurante;
using Microsoft.Extensions.DependencyInjection;

namespace MeatAppBackend.Mapeamentos
{
    public class MapeamentoRepositorios
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRestauranteRepositorio>(provider => new RestauranteRepositorio());            
        }
    }
}
