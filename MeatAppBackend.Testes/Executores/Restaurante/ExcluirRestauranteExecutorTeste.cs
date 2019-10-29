using MeatAppBackend.Executores.Restaurante;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ExcluirRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Testes.ConfiguracaoMock.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Testes.Executores.Restaurante
{
    [TestClass]
    
    public class ExcluirRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IRestauranteRepositorio> _restauranteRepositorio;
        private ExcluirRestauranteExecutor _excluirRestauranteExecutor;
        #endregion

        #region Testes
        private void Inicializar(string restauranteId)
        {
            _restauranteRepositorio = RestauranteRepositorioConfiguracao.Instancia().ExcluirRestaurante(restauranteId).Mock();
            _excluirRestauranteExecutor = new ExcluirRestauranteExecutor(_restauranteRepositorio.Object);
        }
        [TestMethod]
        public void ExcluirRestaurante()
        {
            var restauranteId = "teste";
            Inicializar(restauranteId);
            var requisicao = new ExcluirRestauranteRequisicao()
            {
                RestaurantId = restauranteId
            };
            _excluirRestauranteExecutor.Executar(requisicao);

        }
        #endregion
    }
}
