using MeatAppBackend.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoRestauranteExecutor
{
    public class InserirPedidoRestauranteRequisicao
    {
        public int Id { get; set; }
        public string IdPedido { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
