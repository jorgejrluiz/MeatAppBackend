using MeatAppBackend.Fronteiras.Repositorios;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using MeatAppBackend.Executores.Restaurante;
using MeatAppBackend.Entidades;
using MeatAppBackend.Testes.ConfiguracaoMock.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ListarRestaurantesExecutor;

namespace MeatAppBackend.Testes.Executores.Restaurante
{
    [TestClass]
    public class ListarRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IRestauranteRepositorio> _restauranteRepositorio;
        private ListarRestaurantesExecutor _listarRestauranteExecutor;
        #endregion

        private void Inicializar(List<RestauranteEntidade> retorno)
        {
            _restauranteRepositorio = RestauranteRepositorioConfiguracao.Instancia().ListarRestaurante(retorno).Mock();
            _listarRestauranteExecutor = new ListarRestaurantesExecutor(_restauranteRepositorio.Object);
        }

        #region Testes
        [TestMethod]
        public void ListarRestaurantes()
        {
            List<RestauranteEntidade> retorno = new List<RestauranteEntidade>();

            Inicializar(retorno);

            ListarRestaurantesResultado resposta = _listarRestauranteExecutor.Executar();

            Assert.IsNull(resposta.Restaurantes);
        }
        #endregion

    }
}
