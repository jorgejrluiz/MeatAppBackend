using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Menu.InserirMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Menu
{
    public class InserirMenuRestauranteExecutor : IExecutorSemResultado<InserirMenuRestauranteRequisicao>
    {
        private readonly IMenuRepositorio menuRepositorio;
        private readonly IRestauranteRepositorio restauranteRepositorio;

        public InserirMenuRestauranteExecutor(IMenuRepositorio menuRepositorio, IRestauranteRepositorio restauranteRepositorio)
        {
            this.menuRepositorio = menuRepositorio;
            this.restauranteRepositorio = restauranteRepositorio;
        }

        public void Executar(InserirMenuRestauranteRequisicao requisicao)
        {   
            RestauranteEntidade restaurante = restauranteRepositorio.ObterRestaurante(requisicao.RestauranteID);
            if (restaurante == null)
                throw new BaseException("Restaurante não cadastrado", HttpStatusCode.Conflict);

            var menuInsercao = new MenuEntidade()
            {
                Id = requisicao.Id,
                Imagem = requisicao.Imagem,
                Nome = requisicao.Nome,
                Descricao = requisicao.Descricao,
                Preco = requisicao.Preco,
                RestauranteID = requisicao.RestauranteID

            };
            ValidarCampos(menuInsercao);
            menuRepositorio.InserirMenuRestaurante(menuInsercao);
        }
        private void ValidarCampos(MenuEntidade menu)
        {
            if (String.IsNullOrWhiteSpace(menu.RestauranteID))
                throw new BaseException("Informe o nome do restaurante", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(menu.Id))
                throw new BaseException("Campo invalido", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(menu.Imagem))
                throw new BaseException("Informe a imagem do prato", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace((menu.Preco).ToString()))
                throw new BaseException("Informe preço do prato", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(menu.Nome))
                throw new BaseException("Informe nome", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(menu.Descricao))
                throw new BaseException("Informe a descrição do prato", HttpStatusCode.BadRequest);

        }
    }
}
