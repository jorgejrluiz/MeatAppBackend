using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeatAppBackend.Api.Models
{
    public class PedidoRestauranteModel
    {
        public string IdPedido { get; set; }

        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
