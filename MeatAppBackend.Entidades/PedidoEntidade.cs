using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Entidades
{
    public class PedidoEntidade
    {
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string EnderecoOpcional { get; set; }
        public string FormaPagamento { get; set; }
        public int Id { get; set; }

    }
}
