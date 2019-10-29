using MeatAppBackend.Fronteiras.Executores.Restaurante.ObterRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;


namespace MeatAppBackend.Executores.Restaurante
{
    public class ObterRestauranteExecutor : IExecutor<ObterRestauranteRequisicao, ObterRestauranteResultado>
    {
        private readonly IRestauranteRepositorio restauranteRepositorio;

        public ObterRestauranteExecutor(IRestauranteRepositorio restauranteRepositorio)
        {
            this.restauranteRepositorio = restauranteRepositorio;

        }

        public ObterRestauranteResultado Executar(ObterRestauranteRequisicao requisicao)
        {
            return new ObterRestauranteResultado()
            {
                Restaurante = restauranteRepositorio.ObterRestaurante(requisicao.RestaurantId)
            };
        }
    }
}

