using MeatAppBackend.Fronteiras.Executores.Pedido.ObterPedidosExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Executores.Pedido
{
    public class ObterPedidoIdExecutor : IExecutor<ObterPedidoIdRequisicao, ObterPedidoIdResultado>
    {
        private readonly IPedidoRepositorio pedidoRepositorio;
        public ObterPedidoIdExecutor(IPedidoRepositorio pedidoRepositorio)
        {
            this.pedidoRepositorio = pedidoRepositorio;
        }

        public ObterPedidoIdResultado Executar(ObterPedidoIdRequisicao requisicao)
        {
            
            return new ObterPedidoIdResultado()
            {
                Pedido = pedidoRepositorio.ObterPedido(requisicao.Id)
            };
            
        }
    }
}
