using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeatAppBackend.Api.Models;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ListarRestaurantesExecutor;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Fronteiras.Executores.Menu.ListarMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterRestauranteExecutor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.InserirMenuRestauranteExecutor;
using MeatAppBackend.Utils.Excecoes;
using MeatAppBackend.Fronteiras.Executores.Menu.ExcluirMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.AlterarMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.AlterarPrecoMenuExecutor;

namespace MeatAppBackend.Api.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IExecutorSemRequisicao<ListarMenuRestauranteResultado> listarMenuRestauranteExecutor;
        private readonly IExecutorSemResultado<InserirMenuRestauranteRequisicao> inserirMenuRestauranteExecutor;
        private readonly IExecutorSemResultado<ExcluirMenuRestauranteRequisicao> excluirMenuRestauranteExecutor;
        private readonly IExecutorSemResultado<AlterarMenuRestauranteRequisicao> alterarMenuRestauranteExecutor;
        private readonly IExecutorSemResultado<AlterarPrecoMenuRequisicao> alterarPrecoMenuRestauranteExecutor;

        public MenuController(IExecutorSemRequisicao<ListarMenuRestauranteResultado> listarMenuRestauranteExecutor,
                              IExecutorSemResultado<InserirMenuRestauranteRequisicao> inserirMenuRestauranteExecutor,
                              IExecutorSemResultado<ExcluirMenuRestauranteRequisicao> excluirMenuRestauranteExecutor,
                              IExecutorSemResultado<AlterarMenuRestauranteRequisicao> alterarMenuRestauranteExecutor,
                              IExecutorSemResultado<AlterarPrecoMenuRequisicao> alterarPrecoMenuRestauranteExecutor)
        {
            this.listarMenuRestauranteExecutor = listarMenuRestauranteExecutor;
            this.inserirMenuRestauranteExecutor = inserirMenuRestauranteExecutor;
            this.excluirMenuRestauranteExecutor = excluirMenuRestauranteExecutor;
            this.alterarMenuRestauranteExecutor = alterarMenuRestauranteExecutor;
            this.alterarPrecoMenuRestauranteExecutor = alterarPrecoMenuRestauranteExecutor;
        }
        /// <summary>
        /// Lista todos os pratos
        /// </summary>
        /// <response code="200">Retorna todos os restaurantes</response>
        /// <response code="404">Se não houver restaurante</response>    
        [HttpGet("")]
        public ActionResult<IEnumerable<MenuModel>> ListarMenuRestaurante()
        {
            var resultado = listarMenuRestauranteExecutor.Executar();
            IEnumerable<MenuModel> menus = resultado.Menus.Select(rest => new MenuModel()
            {
                Id = rest.Id,
                Imagem = rest.Imagem,
                Nome = rest.Nome,
                Descricao = rest.Descricao,
                Preco = rest.Preco,
                RestauranteID = rest.RestauranteID
            });
            return Ok(menus);
        }
        /// <summary>
        /// Insere Prato
        /// </summary>
        /// <param MenuEntidade="Menu"></param>
        /// <response code="201">Sucesso na inserção</response>
        /// <response code="400">Se houver algum erro</response>   
        [HttpPost("")]
        public ActionResult<IEnumerable<MenuModel>> InserirMenuRestaurante(MenuEntidade Menu)
        {
            var requisicao = new InserirMenuRestauranteRequisicao()
            {
                Id = Menu.Id,
                Imagem = Menu.Imagem,
                Nome = Menu.Nome,
                Descricao = Menu.Descricao,
                Preco = Menu.Preco,
                RestauranteID = Menu.RestauranteID
            };
            try
            {
                inserirMenuRestauranteExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(201);
        }

        /// <summary>
        /// Excluir Prato Restaurante.
        /// </summary>
        /// <param string="Id"></param>
        /// <response code="204">Se o prato foi excluido</response>
        /// <response code="400">Erro ao excluir</response>
        /// <response code="404">Se não houver o restaurante procurado</response>
        [HttpDelete()]
        public ActionResult<IEnumerable<MenuModel>> ExcluirMenu(string Id)
        {
            var requisicao = new ExcluirMenuRestauranteRequisicao()
            {
                Id = Id
            };
            try
            {
                excluirMenuRestauranteExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return NoContent();
        }

        /// <summary>
        /// Altera Prato
        /// </summary>
        /// <param MenuEntidade="Menu"></param>
        /// <response code="201">Sucesso na inserção</response>
        /// <response code="400">Se houver algum erro</response>   
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<MenuModel>> AlterarMenuRestaurante(MenuEntidade Menu)
        {
            var requisicao = new AlterarMenuRestauranteRequisicao()
            {
                Id = Menu.Id,
                Imagem = Menu.Imagem,
                Nome = Menu.Nome,
                Descricao = Menu.Descricao,
                Preco = Menu.Preco,
                RestauranteID = Menu.RestauranteID
            };
            try
            {
                alterarMenuRestauranteExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(201);
        }
        /// <summary>
        /// Altera Preço do prato
        /// </summary>
        /// <param string="Id"></param>
        /// <param double="Preco"></param>
        /// <response code="202">Avaliacao alterado com sucesso</response>  
        /// <response code="400">Erro ao alterar</response>  
        /// <response code="404">Se não houver o restaurante para alterar</response>   
        [HttpPatch("{Id}")]
        public ActionResult<IEnumerable<MenuModel>> AlterarPrecoMenuRestaurante(string Id, double Preco)
        {
            var requisicao = new AlterarPrecoMenuRequisicao()
            {
                Id = Id,
                Preco = Preco
            };
            try
            {
                alterarPrecoMenuRestauranteExecutor.Executar(requisicao);
            }
            catch (BaseException ex)
            {
                return StatusCode((int)ex.HttpStatus, ex.Mensagem);
            }
            return StatusCode(201);
        }

    }

    
}