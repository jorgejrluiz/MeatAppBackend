using MeatAppBackend.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Fronteiras.Executores.Pedido.ObterPedidosExecutor
{
    public class ObterPedidosResultado
    {
        public IEnumerable<PedidoRestauranteEntidade> Pedidos { get; set; }
    }
}
