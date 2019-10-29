using MeatAppBackend.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoExecutor
{
    public class InserirPedidoRequisicao
    {
        public int Id { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string EnderecoOpcional { get; set; }
        
        public string FormaPagamento { get; set; }
    }
}
