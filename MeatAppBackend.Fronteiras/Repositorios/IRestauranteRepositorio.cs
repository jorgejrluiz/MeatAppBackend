using MeatAppBackend.Entidades;
using System.Collections.Generic;

namespace MeatAppBackend.Fronteiras.Repositorios
{
    public interface IRestauranteRepositorio
    {
        IEnumerable<RestauranteEntidade> ListarRestaurantes();
<<<<<<< Updated upstream
=======
        RestauranteEntidade ObterRestaurante(string restauranteId);
        void InserirRestaurante(RestauranteEntidade restaurante);
        void ExcluirRestaurante(string restauranteId);
        void AlterarRestaurante(RestauranteEntidade restaurante);
        void AlterarAvaliacaoRestaurante(string restauranteId, double Avaliacao);
>>>>>>> Stashed changes
    }
}
