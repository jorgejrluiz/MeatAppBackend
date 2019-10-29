using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeatAppBackend.Executores.Avaliacao;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Api.Models;
using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Avaliacao.InserirAvaliacaoExecutor;
using MeatAppBackend.Fronteiras.Executores.Avaliacao.ListarAvaliacaoExecutor;
using MeatAppBackend.Fronteiras.Executores.Avaliacao.ExcluirAvaliacaoExecutor;
using MeatAppBackend.Utils.Excecoes;

namespace MeatAppBackend.Api.Controllers
{
    [Route("api/avaliacoes")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IExecutorSemRequisicao<ListarAvaliacaoResultado> ListarAvaliacaoExecutor;
        private readonly IExecutorSemResultado<InserirAvaliacaoRequisicao> inserirAvaliacaoExecutor;
        private readonly IExecutorSemResultado<ExcluirAvaliacaoExecutor> excluirAvaliacaoExecutor;


        public AvaliacaoController(IExecutorSemRequisicao<ListarAvaliacaoResultado> listarAvaliacaoExecutor,
                                    IExecutorSemResultado<InserirAvaliacaoRequisicao> inserirAvaliacaoExecutor,
                                    IExecutorSemResultado<ExcluirAvaliacaoExecutor> excluirAvaliacaoExecutor)
        {
            this.ListarAvaliacaoExecutor = listarAvaliacaoExecutor;
            this.inserirAvaliacaoExecutor = inserirAvaliacaoExecutor;
            this.excluirAvaliacaoExecutor = excluirAvaliacaoExecutor;
        }

        /// <summary>
        /// Lista todas as Avaliacoes
        /// </summary>
        /// <response code="200">Retorna todos os restaurantes</response>
        /// <response code="404">Se não houver restaurante</response>    
        [HttpGet("")]
        public ActionResult<IEnumerable<AvaliacaoModel>> ListarAvaliacao()
        {
            var resultado = ListarAvaliacaoExecutor.Executar();
            IEnumerable<AvaliacaoModel> avaliacoes = resultado.Avaliacoes.Select(rest => new AvaliacaoModel()
            {
                Nome = rest.Nome,
                Data = rest.Data,
                Nota = rest.Nota,
                Comentario = rest.Comentario,
                RestauranteID = rest.RestauranteID,
            });
            return StatusCode(200, avaliacoes);
        }

        /// <summary>
        /// Insere nova avaliacao
        /// </summary>
        /// <param AvaliacaoEntidade="avaliacao"></param>
        /// <response code="201">Sucesso na inserção</response>
        /// <response code="400">Se houver algum erro</response>   
        [HttpPost("")]
        public ActionResult<IEnumerable<AvaliacaoModel>> InserirAvaliacao(AvaliacaoEntidade avaliacao)
        {
            var requisicao = new InserirAvaliacaoRequisicao()
            {
                Nome = avaliacao.Nome,
                Data = avaliacao.Data,
                Nota = avaliacao.Nota,
                Comentario = avaliacao.Comentario,
                RestauranteID = avaliacao.RestauranteID,
            };
            try
            {
                inserirAvaliacaoExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(201);
        }

        /// <summary>
        /// Exclui avaliacao
        /// </summary>
        /// <param string="Id"></param>
        /// <response code="204">Se a Avaliacao foi excluida</response>
        /// <response code="400">Erro ao excluir</response>   
        /// <response code="404">se não houver avaliacao</response>
        [HttpDelete()]
        public ActionResult<IEnumerable<AvaliacaoModel>> ExcluirAvaliacao(string Id)
        {
            var requisicao = new ExcluirAvaliacaoRequisicao(){
                Id = Id
            };
            try
            {
                excluirAvaliacaoExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return NoContent();
        }


        
    }
}