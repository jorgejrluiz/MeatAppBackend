using MeatAppBackend.Executores.Restaurante;
using MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarAvaliacaoRestauranteRequisicao;
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
    public class AlterarAvaliacaoRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IRestauranteRepositorio> _restauranteRepositorio;
        private AlterarAvaliacaoRestauranteExecutor _alterarAvaliacaoRestauranteExecutor;
        #endregion

        #region
        private void Inicializar(string restauranteId, double Avaliacao)
        {
            _restauranteRepositorio = RestauranteRepositorioConfiguracao.Instancia().AlterarAvaliacaoRestaurante(restauranteId, Avaliacao).Mock();
            _alterarAvaliacaoRestauranteExecutor = new AlterarAvaliacaoRestauranteExecutor(_restauranteRepositorio.Object);
        }

        [TestMethod]
        public void AlterarAvaliacaoRestaurante()
        {
            string restauranteId = "starbucks";
            double Avaliacao = 5;
            var requisicao = new AlterarAvaliacaoRestauranteRequisicao
            {
                restauranteID = restauranteId,
                Avaliacao = Avaliacao
            };
            Inicializar(restauranteId, Avaliacao);

            _alterarAvaliacaoRestauranteExecutor.Executar(requisicao);
        }
        #endregion
    }
}
