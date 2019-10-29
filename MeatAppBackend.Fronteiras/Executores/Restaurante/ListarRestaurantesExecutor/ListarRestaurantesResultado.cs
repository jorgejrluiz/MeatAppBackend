using MeatAppBackend.Entidades;
using System.Collections.Generic;

namespace MeatAppBackend.Fronteiras.Executores.Restaurante.ListarRestaurantesExecutor
{
    public class ListarRestaurantesResultado
    {
        public IEnumerable<RestauranteEntidade> Restaurantes { get; set; }
    }
}
