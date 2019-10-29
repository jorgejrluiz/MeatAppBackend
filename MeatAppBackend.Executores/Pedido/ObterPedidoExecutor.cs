using MeatAppBackend.Fronteiras.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using MeatAppBackend.Fronteiras.Executores.Pedido.ObterPedidosExecutor;
using MeatAppBackend.Fronteiras.Repositorios;

namespace MeatAppBackend.Executores.Pedido
{
    public class ObterPedidoExecutor : IExecutor<ObterPedidosRequisicao, ObterPedidosResultado>
    {
        private readonly IPedidoRepositorio pedidoRepositorio;
        public ObterPedidoExecutor(IPedidoRepositorio pedidoRepositorio)
        {
            this.pedidoRepositorio = pedidoRepositorio;
        }
        public ObterPedidosResultado Executar(ObterPedidosRequisicao requisicao)
        {
            return new ObterPedidosResultado()
            {
                Pedidos = pedidoRepositorio.ObterPedidos(requisicao.RestaurantId)
            };
        }
    }
}
