using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Menu.AlterarMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Menu
{
    public class AlterarMenuRestauranteExecutor : IExecutorSemResultado<AlterarMenuRestauranteRequisicao>
    {
        private readonly IMenuRepositorio menuRepositorio;

        public AlterarMenuRestauranteExecutor(IMenuRepositorio menuRepositorio)
        {
            this.menuRepositorio = menuRepositorio;
        }

        public void Executar(AlterarMenuRestauranteRequisicao requisicao)
        {
            var menuUpdate = new MenuEntidade()
            {
                Id = requisicao.Id,
                Imagem = requisicao.Imagem,
                Nome = requisicao.Nome,
                Descricao = requisicao.Descricao,
                Preco = requisicao.Preco,
                RestauranteID = requisicao.RestauranteID

            };
            ValidarCampos(menuUpdate);
            menuRepositorio.AlterarMenu(menuUpdate);
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
