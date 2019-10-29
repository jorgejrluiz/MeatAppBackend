using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeatAppBackend.Api.Models;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ListarRestaurantesExecutor;
using MeatAppBackend.Fronteiras.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< Updated upstream
=======
using MeatAppBackend.Fronteiras.Executores.Menu.ListarMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ObterRestauranteExecutor;
using MeatAppBackend.Fronteiras.Fronteiras.Shared;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Avaliacao.ObterAvaliacaoExecutor;
using MeatAppBackend.Fronteiras.Executores.Pedido.ObterPedidosExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.InserirRestauranteExecutor;
using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ExcluirRestauranteExecutor;
using MeatAppBackend.Utils.Excecoes;
using MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarAvaliacaoRestauranteRequisicao;
>>>>>>> Stashed changes

namespace MeatAppBackend.Api.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
<<<<<<< Updated upstream
        private readonly IExecutorSemRequisicao<ListarRestaurantesResultado> listarRestaurantesExecutor;

        public RestauranteController(IExecutorSemRequisicao<ListarRestaurantesResultado> listarRestaurantesExecutor)
        {
            this.listarRestaurantesExecutor = listarRestaurantesExecutor;
=======
        private readonly IExecutor<ObterMenuRestauranteRequisicao, ObterMenuRestauranteResultado> obterMenuRestauranteExecutor;
        private readonly IExecutorSemRequisicao<ListarRestaurantesResultado> listarRestaurantesExecutor;
        private readonly IExecutor<ObterRestauranteRequisicao, ObterRestauranteResultado> obterRestauranteExecutor;
        private readonly IExecutor<ObterAvaliacaoRequisicao, ObterAvaliacaoResultado> obterAvalaiacaoExecutor;
        private readonly IExecutor<ObterPedidosRequisicao, ObterPedidosResultado> obterPedidoExecutor;
        private readonly IExecutorSemResultado<InserirRestauranteRequisicao> inserirRestauranteExecutor;
        private readonly IExecutorSemResultado<ExcluirRestauranteRequisicao> excluirRestauranteExecutor;
        private readonly IExecutorSemResultado<AlterarRestauranteRequisicao> alterarRestauranteExecutor;
        private readonly IExecutorSemResultado<AlterarAvaliacaoRestauranteRequisicao> alterarAvaliacaoRestauranteExecutor;

        public RestauranteController(IExecutor<ObterMenuRestauranteRequisicao, ObterMenuRestauranteResultado> obterMenuRestauranteExecutor,
                                     IExecutorSemRequisicao<ListarRestaurantesResultado> listarRestaurantesExecutor,
                                     IExecutor<ObterRestauranteRequisicao, ObterRestauranteResultado> obterRestauranteExecutor,
                                     IExecutor<ObterAvaliacaoRequisicao, ObterAvaliacaoResultado> obterAvalaiacaoExecutor,
                                     IExecutor<ObterPedidosRequisicao, ObterPedidosResultado> obterPedidoExecutor,
                                     IExecutorSemResultado<InserirRestauranteRequisicao> inserirRestauranteExecutor,
                                     IExecutorSemResultado<ExcluirRestauranteRequisicao> excluirRestauranteExecutor,
                                     IExecutorSemResultado<AlterarRestauranteRequisicao> alterarRestauranteExecutor,
                                     IExecutorSemResultado<AlterarAvaliacaoRestauranteRequisicao> alterarAvaliacaoRestauranteExecutor)
        {
            this.obterMenuRestauranteExecutor = obterMenuRestauranteExecutor;
            this.listarRestaurantesExecutor = listarRestaurantesExecutor;
            this.obterRestauranteExecutor = obterRestauranteExecutor;
            this.obterAvalaiacaoExecutor = obterAvalaiacaoExecutor;
            this.obterPedidoExecutor = obterPedidoExecutor;
            this.inserirRestauranteExecutor = inserirRestauranteExecutor;
            this.excluirRestauranteExecutor = excluirRestauranteExecutor;
            this.alterarRestauranteExecutor = alterarRestauranteExecutor;
            this.alterarAvaliacaoRestauranteExecutor = alterarAvaliacaoRestauranteExecutor;
>>>>>>> Stashed changes
        }
        /// <summary>
        /// Listar Restaurantes
        /// </summary>
        /// <response code="200">Retorna todos os restaurantes</response> 
        [HttpGet("")]
        
        public ActionResult<IEnumerable<RestauranteModel>> ListarRestaurantes()
        {
            var resultado = listarRestaurantesExecutor.Executar();

            IEnumerable<RestauranteModel> restaurantes = resultado.Restaurantes.Select(rest => new RestauranteModel()
            {
                Avaliacao = rest.Avaliacao,
                Categoria = rest.Categoria,
                Funcionamento = rest.Funcionamento,
                Id = rest.Id,
                Imagem = rest.Imagem,
                Nome = rest.Nome,
                Sobre = rest.Sobre,
                TempoEntrega = rest.TempoEntrega
            });

            return Ok(restaurantes);

        }
<<<<<<< Updated upstream
=======
        /// <summary>
        /// Obter restaurante
        /// </summary>
        /// <param string="idRestaurante"></param>
        /// <response code="200">Retorna todos os restaurantes</response>
        /// <response code="400">Erro ao buscar</response> 
        /// <response code="404">Se não houver o restaurante procurado</response>     
        [HttpGet("{idRestaurante}")]
        public ActionResult<IEnumerable<RestauranteModel>> ObterRestaurante([FromRoute]string idRestaurante)
        {
            var requisicao = new ObterRestauranteRequisicao()
            {
                RestaurantId = idRestaurante
            };
            var resultado = obterRestauranteExecutor.Executar(requisicao);
            if (resultado == null || resultado.Restaurante == null)
                return NotFound();

            RestauranteModel restaurante = new RestauranteModel()
            {
                Avaliacao = resultado.Restaurante.Avaliacao,
                Categoria = resultado.Restaurante.Categoria,
                Funcionamento = resultado.Restaurante.Funcionamento,
                Id = resultado.Restaurante.Id,
                Imagem = resultado.Restaurante.Imagem,
                Nome = resultado.Restaurante.Nome,
                Sobre = resultado.Restaurante.Sobre,
                TempoEntrega = resultado.Restaurante.TempoEntrega
            };
            return Ok(restaurante);
        }
        /// <summary>
        /// Obtem menu com os pratos do restaurante
        /// </summary>
        /// <param string="idRestaurante"></param>
        /// <response code="200">Retorna o menu do restaurante</response>
        /// <response code="400">Erro ao buscar</response> 
        /// <response code="404">Se não houver o restaurante/menu procurado</response>   
        [HttpGet("{idRestaurante}/menu")]
        public ActionResult<IEnumerable<MenuModel>> ObterMenu([FromRoute]string idRestaurante)
        {
            var requisicao = new ObterMenuRestauranteRequisicao()
            {
                RestaurantId = idRestaurante
            };
            var resultado = obterMenuRestauranteExecutor.Executar(requisicao);
            if (resultado == null || resultado.Menu == null)
                return NotFound();

            IEnumerable<MenuModel> Menu = resultado.Menu.Select(rest => new MenuModel()
            {
                Id = rest.Id,
                Imagem = rest.Imagem,
                Nome = rest.Nome,
                Descricao = rest.Descricao,
                Preco = rest.Preco,
                RestauranteID = rest.RestauranteID,
            });
            return Ok(Menu);
        }
        /// <summary>
        /// Obter Avaliacao do restaurante
        /// </summary>
        /// <param string="idRestaurante"></param>
        /// <response code="200">Retorna as avaliacoes do restaurante</response>
        /// <response code="404">Se não houver o restaurante/avaliacao procurado</response>   
        [HttpGet("{idRestaurante}/avaliacao")]
        public ActionResult<IEnumerable<AvaliacaoModel>> ObterAvaliacao([FromRoute]string idRestaurante)
        {
            var requisicao = new ObterAvaliacaoRequisicao()
            {
                RestaurantId = idRestaurante
            };
            var resultado = obterAvalaiacaoExecutor.Executar(requisicao);
            if (resultado == null || resultado.Avaliacao == null)
                return NotFound();


            IEnumerable<AvaliacaoModel> avaliacoes = resultado.Avaliacao.Select(rest => new AvaliacaoModel()
            {
                Nome = rest.Nome,
                Data = rest.Data,
                Nota = rest.Nota,
                Comentario = rest.Comentario,
                RestauranteID = rest.RestauranteID,
            });
            return Ok(avaliacoes);
        }
        /// <summary>
        /// Obter Pedidos do restaurante
        /// </summary>
        /// <param string="idRestaurante"></param>
        /// <response code="200">Retorna os pedidos do restaurante</response>
        /// <response code="404">Se não houver o restaurante procurado</response>   
        [HttpGet("{idRestaurante}/pedidos")]
        public ActionResult<IEnumerable<PedidoRestauranteModel>> ObterPedidos([FromRoute]string idRestaurante)
        {
            var requisicao = new ObterPedidosRequisicao()
            {
                RestaurantId = idRestaurante
            };
            var resultado = obterPedidoExecutor.Executar(requisicao);
            if (resultado == null || resultado.Pedidos == null)
                return NotFound();
            IEnumerable<PedidoRestauranteModel> pedidos = resultado.Pedidos.Select(rest => new PedidoRestauranteModel()
            {
                Nome = rest.Nome,
                IdPedido = rest.IdPedido,
                Quantidade = rest.Quantidade,
            });
            return Ok(pedidos);
        }
        /// <summary>
        /// Inserir Restaurante
        /// </summary>
        /// <param RestauranteEntidade="restaurante"></param>
        /// <response code="201">Sucesso na inserção</response>
        /// <response code="400">Se houver algum erro</response>   
        [HttpPost]
        public ActionResult<IEnumerable<RestauranteModel>> InserirRestaurante(RestauranteEntidade restaurante) //string idRestaurante, string Nome, string Categoria, string TempoEntrega, double Avaliacao, string Imagem, string Sobre, string Funcionamento)
        {
            var requisicao = new InserirRestauranteRequisicao()
            {
                Id = restaurante.Id,
                Nome = restaurante.Nome,
                Categoria = restaurante.Categoria,
                TempoEntrega = restaurante.TempoEntrega,
                Avaliacao = restaurante.Avaliacao,
                Imagem = restaurante.Imagem,
                Sobre = restaurante.Sobre,
                Funcionamento = restaurante.Funcionamento
            };
            try
            {
                inserirRestauranteExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(201);
        }
        /// <summary>
        /// Excluir Restaurante.
        /// </summary>
        /// <param string="restauranteId"></param>
        /// <response code="204">Se o restaurante foi excluido</response>
        /// <response code="400">Erro ao excluir</response>
        /// <response code="404">Se não houver o restaurante procurado</response>
        [HttpDelete()]
        public ActionResult<IEnumerable<RestauranteModel>> ExcluirRestaurante(string restauranteId) 
        {
            var requisicao = new ExcluirRestauranteRequisicao()
            {
                RestaurantId = restauranteId
            };
            try
            {
                excluirRestauranteExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return NoContent();
        }
        /// <summary>
        /// Alterar valores Restaurante.
        /// </summary>
        /// <param RestauranteEntidade="restaurante"></param>
        /// <response code="202">Restaurante alterado com sucesso</response>  
        /// <response code="400">Erro ao alterar</response>
        /// <response code="404">Se não houver o restaurante para alterar</response>
        [HttpPut("{idRestaurant}")]
        public ActionResult<IEnumerable<RestauranteModel>> AlterarRestaurante(RestauranteEntidade restaurante) 
        {
            var requisicao = new AlterarRestauranteRequisicao()
            {
                Id = restaurante.Id,
                Nome = restaurante.Nome,
                Categoria = restaurante.Categoria,
                TempoEntrega = restaurante.TempoEntrega,
                Avaliacao = restaurante.Avaliacao,
                Imagem = restaurante.Imagem,
                Sobre = restaurante.Sobre,
                Funcionamento = restaurante.Funcionamento
            };
            try
            {
                alterarRestauranteExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(202);
        }
        /// <summary>
        /// Alterar Avaliação restaurante
        /// </summary>
        /// <param string="restauranteId"></param>
        /// <param double="Avaliacao"></param> 
        /// <response code="202">Avaliacao alterado com sucesso</response>  
        /// <response code="400">Erro ao alterar</response>  
        /// <response code="404">Se não houver o restaurante para alterar</response>
        [HttpPatch("{idRestaurante}")]
        public ActionResult<IEnumerable<RestauranteModel>> AlterarAvaliacaoRestaurante(string idRestaurante, double Avaliacao) //string idRestaurante, string Nome, string Categoria, string TempoEntrega, double Avaliacao, string Imagem, string Sobre, string Funcionamento)
        {
            var requisicao = new AlterarAvaliacaoRestauranteRequisicao()
            {
                restauranteID = idRestaurante,
                Avaliacao = Avaliacao,
            };
            try
            {
                alterarAvaliacaoRestauranteExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(200);
        }
>>>>>>> Stashed changes
    }
}