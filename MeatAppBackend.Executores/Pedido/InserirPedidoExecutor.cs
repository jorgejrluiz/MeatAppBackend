using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Pedido
{
    public class InserirPedidoExecutor : IExecutorSemResultado<InserirPedidoRequisicao>
    {
        private readonly IPedidoRepositorio pedidoRepositorio;

        public InserirPedidoExecutor(IPedidoRepositorio pedidoRepositorio)
        {
            this.pedidoRepositorio = pedidoRepositorio;

        }
        public void Executar(InserirPedidoRequisicao requisicao)
        {
            PedidoEntidade pedido = pedidoRepositorio.ObterPedido(requisicao.Id);
            if (pedido != null)
                throw new BaseException("Endereco já cadastrado", HttpStatusCode.Conflict);

            var pedidoInsercao = new PedidoEntidade()
            {
                Endereco = requisicao.Endereco,
                Numero = requisicao.Numero,
                EnderecoOpcional = requisicao.EnderecoOpcional,
                FormaPagamento = requisicao.FormaPagamento,
                Id = requisicao.Id
            };
            ValidarCampos(pedidoInsercao);
            pedidoRepositorio.InserirPedidoEntrega(pedidoInsercao);
        }

        private void ValidarCampos(PedidoEntidade pedido)
        {
            if (String.IsNullOrWhiteSpace(pedido.Endereco))
                throw new BaseException("Informe o Endereco", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace((pedido.Numero).ToString()))
                throw new BaseException("Informe Numero do endereco", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(pedido.EnderecoOpcional))
                throw new BaseException("Informe o complemento", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace((pedido.FormaPagamento).ToString()))
                throw new BaseException("Informe a forma de pagamento", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace((pedido.Id).ToString()))
                throw new BaseException("Informe o Id", HttpStatusCode.BadRequest);
        }
    }
}
