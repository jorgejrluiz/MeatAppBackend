using MeatAppBackend.Fronteiras.Executores.Restaurante.ListarRestaurantesExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;

namespace MeatAppBackend.Executores.Restaurante
{
    public class ListarRestaurantesExecutor : IExecutorSemRequisicao<ListarRestaurantesResultado>
    {
        private readonly IRestauranteRepositorio restauranteRepositorio;

        public ListarRestaurantesExecutor(IRestauranteRepositorio restauranteRepositorio)
        {
            this.restauranteRepositorio = restauranteRepositorio;
        }


        public ListarRestaurantesResultado Executar()
        {
            return new ListarRestaurantesResultado()
            {
                Restaurantes = restauranteRepositorio.ListarRestaurantes()
            };
        }
    }
}
