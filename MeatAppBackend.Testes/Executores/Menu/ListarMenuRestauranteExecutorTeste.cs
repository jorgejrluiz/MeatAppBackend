using MeatAppBackend.Entidades;
using MeatAppBackend.Executores.Menu;
using MeatAppBackend.Fronteiras.Executores.Menu.ListarMenuRestauranteExecutor;
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
    public class ListarMenuRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IMenuRepositorio> _menuRepositorio;
        private ListarMenuRestauranteExecutor _listarMenuRestauranteExecutor;
        #endregion

        private void Inicializar(List<MenuEntidade> retorno)
        {
            _menuRepositorio = MenuRepositorioConfiguracao.Instancia().ListarMenuRestaurante(retorno).Mock();
            _listarMenuRestauranteExecutor = new ListarMenuRestauranteExecutor(_menuRepositorio.Object);
        }

        #region Testes
        [TestMethod]
        public void ListarMenu()
        {
            List<MenuEntidade> retorno = new List<MenuEntidade>();

            Inicializar(retorno);

            ListarMenuRestauranteResultado resposta = _listarMenuRestauranteExecutor.Executar();

            Assert.IsNull(resposta.Menus);
        }
        #endregion
    }
}
