using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Menu;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Pedido
{
    public class InserirPedidoRestauranteExecutor : IExecutorSemResultado<InserirPedidoRestauranteRequisicao>
                                                    
    {
        private readonly IPedidoRepositorio pedidoRepositorio;
        private readonly IMenuRepositorio menuRepositorio;
        public InserirPedidoRestauranteExecutor(IPedidoRepositorio pedidoRepositorio, IMenuRepositorio menuRepositorio)
        {
            this.pedidoRepositorio = pedidoRepositorio;
            this.menuRepositorio = menuRepositorio;

        }
        public void Executar(InserirPedidoRestauranteRequisicao requisicao)
        {
            MenuEntidade menu = menuRepositorio.ObterPratoMenu(requisicao.Nome);
            if (menu == null)
                throw new BaseException("Prato não existe", HttpStatusCode.Conflict);

            var pedidoInsercao = new PedidoRestauranteEntidade()
            {
                Id = requisicao.Id,
                IdPedido = requisicao.IdPedido,
                Nome = requisicao.Nome,
                Quantidade = requisicao.Quantidade
            };
            ValidarCampos(pedidoInsercao);
            pedidoRepositorio.InserirPedidoRestaurante(pedidoInsercao);
        }

        private void ValidarCampos(PedidoRestauranteEntidade pedido)
        {
            if (String.IsNullOrWhiteSpace((pedido.Id).ToString()))
                throw new BaseException("Informe o Id do Pedido", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(pedido.IdPedido))
                throw new BaseException("Informe o Id da entrega do restaurante", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(pedido.Nome))
                throw new BaseException("Informe o Nome do prato", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace((pedido.Quantidade).ToString()))
                throw new BaseException("Informe a Quantidade", HttpStatusCode.BadRequest);
        }
    }
}
