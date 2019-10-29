using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MeatAppBackend.Api.Models;
using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.InserirPedidoRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.ListarPedidosExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.ObterPedidosExecutor;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeatAppBackend.Api.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IExecutorSemRequisicao<ListarPedidosResultado> listarPedidoExecutor;
        private readonly IExecutorSemResultado<InserirPedidoRequisicao> inserirPedidoExecutor;
        private readonly IExecutorSemResultado<InserirPedidoRestauranteRequisicao> inserirPedidoRestauranteExecutor;
        public PedidoController(IExecutorSemRequisicao<ListarPedidosResultado> listarPedidoExecutor,
                                IExecutorSemResultado<InserirPedidoRequisicao> inserirPedidoExecutor,
                                IExecutorSemResultado<InserirPedidoRestauranteRequisicao> inserirPedidoRestauranteExecutor)
        {
            this.listarPedidoExecutor = listarPedidoExecutor;
            this.inserirPedidoExecutor = inserirPedidoExecutor;
            this.inserirPedidoRestauranteExecutor = inserirPedidoRestauranteExecutor;

        }
        /// <summary>
        /// Lista todos os pedidos
        /// </summary>
        /// <param string="idRestaurante"></param>
        /// <response code="200">Retorna todos os restaurantes</response>
        /// <response code="404">Se não houver restaurante</response> 
        [HttpGet("")]
        public ActionResult<IEnumerable<PedidoModel>> ListarPedidos()
        {
            var resultado = listarPedidoExecutor.Executar();
            IEnumerable<PedidoModel> pedidos = resultado.Pedidos.Select(rest => new PedidoModel()
            {
                Endereco = rest.Endereco,
                Numero = rest.Numero,
                EnderecoOpcional = rest.EnderecoOpcional,
                FormaPagamento = rest.FormaPagamento,
                Id = rest.Id
            });
            return Ok(pedidos);
        }
        /// <summary>
        /// Insere pedido de entrega
        /// </summary>
        /// <param string="idRestaurante"></param>
        /// <response code="201">Sucesso na inserção</response>
        /// <response code="400">Se houver algum erro</response>   
        [HttpPost("")]
        public ActionResult<IEnumerable<PedidoModel>> InserirPedido(PedidoEntidade pedido)
        {
           var pedidoInsert = new InserirPedidoRequisicao()
            {
                Endereco = pedido.Endereco,
                Numero = pedido.Numero,
                EnderecoOpcional = pedido.EnderecoOpcional,
                FormaPagamento = pedido.FormaPagamento,
                Id = pedido.Id
            };
            try
            {
                inserirPedidoExecutor.Executar(pedidoInsert);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(201);
        }
        /// <summary>
        /// Insere prato no pedido
        /// </summary>
        /// <param string="idRestaurante"></param>
        /// <response code="201">Sucesso na inserção</response>
        /// <response code="400">Se houver algum erro</response>   
        [HttpPost("restaurante")]
        public ActionResult<IEnumerable<PedidoRestauranteModel>> InserirPedidoRestaurante(PedidoRestauranteEntidade pedido)
        {
            
            var pedidoInsert = new InserirPedidoRestauranteRequisicao()
            {
                Id = pedido.Id,
                IdPedido = pedido.IdPedido,
                Nome = pedido.Nome,
                Quantidade = pedido.Quantidade
            };
            try
            {
                inserirPedidoRestauranteExecutor.Executar(pedidoInsert);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(201);
        }
    }
}