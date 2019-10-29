using MeatAppBackend.Entidades;
using System.Collections.Generic;


namespace MeatAppBackend.Fronteiras.Repositorios
{
    public interface IPedidoRepositorio 
    {
        IEnumerable<PedidoEntidade> ListarPedidos();
        IEnumerable<PedidoRestauranteEntidade> ObterPedidos(string restaurantId);
        PedidoEntidade ObterPedido(int id);
        void InserirPedidoEntrega(PedidoEntidade pedido);
        void InserirPedidoRestaurante(PedidoRestauranteEntidade pedidoItens);
    }
}
