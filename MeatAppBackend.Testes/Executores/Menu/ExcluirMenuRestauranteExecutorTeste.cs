using MeatAppBackend.Executores.Menu;
using MeatAppBackend.Fronteiras.Executores.Menu.ExcluirMenuRestauranteExecutor;
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
    public class ExcluirMenuRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IMenuRepositorio> _menuRepositorio;
        private ExcluirMenuRestauranteExecutor _excluirMenuRestauranteExecutor;
        #endregion

        private void Inicializar(string Id)
        {
            _menuRepositorio = MenuRepositorioConfiguracao.Instancia().ExcluirMenuRestaurante(Id).Mock();
            _excluirMenuRestauranteExecutor = new ExcluirMenuRestauranteExecutor(_menuRepositorio.Object);
        }

        #region Testes
        [TestMethod]
        public void ExcluirMenu()
        {
            string Id = "fries";
            Inicializar(Id);
            var requisicao = new ExcluirMenuRestauranteRequisicao()
            {
                Id = Id
            };
            _excluirMenuRestauranteExecutor.Executar(requisicao);
        }
        #endregion
    }
}
