using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Entidades
{
    public class PedidoRestauranteEntidade
    {
        public int Id { get; set; }
        public string IdPedido { get; set; }

        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
