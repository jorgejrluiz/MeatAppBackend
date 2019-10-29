using MeatAppBackend.Entidades;
using MeatAppBackend.Executores.Menu;
using MeatAppBackend.Fronteiras.Executores.Menu.InserirMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Testes.ConfiguracaoMock.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Testes.Executores.Menu
{   
    [TestClass]
    public class InserirMenuRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IMenuRepositorio> _menuRepositorio;
        private Mock<IRestauranteRepositorio> _restauranteRepositorio;

        private InserirMenuRestauranteExecutor _inserirMenuRestauranteExecutor;
        
        #endregion

        private void Inicializar(MenuEntidade menu, RestauranteEntidade restaurante)
        {
            _menuRepositorio = MenuRepositorioConfiguracao.Instancia().InserirMenuRestaurante(menu).Mock();
            _restauranteRepositorio =  RestauranteRepositorioConfiguracao.Instancia().ObterRestaurante(menu.RestauranteID, restaurante).Mock();
            _inserirMenuRestauranteExecutor = new InserirMenuRestauranteExecutor(_menuRepositorio.Object, _restauranteRepositorio.Object);
        }

        #region Testes
        [TestMethod]
        public void InserirMenu()
        {
            var restaurante = new RestauranteEntidade
            {

            };
            var menu = new MenuEntidade
            {
                Id = "Teste",
                Imagem = "Teste",
                Nome = "Teste",
                Descricao = "Teste",
                Preco = 100,
                RestauranteID = "starbucks"
            };
            var requisicao = new InserirMenuRestauranteRequisicao
            {
                Id = "Teste",
                Imagem = "Teste",
                Nome = "Teste",
                Descricao = "Teste",
                Preco = 100,
                RestauranteID = "starbucks"
            };
            Inicializar(menu, restaurante);

            _inserirMenuRestauranteExecutor.Executar(requisicao);
        }
        #endregion
    }
}
