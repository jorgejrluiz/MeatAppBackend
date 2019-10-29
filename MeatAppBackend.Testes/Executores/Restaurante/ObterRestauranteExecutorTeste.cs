using MeatAppBackend.Fronteiras.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MeatAppBackend.Testes.ConfiguracaoMock.Repositorios;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ObterRestauranteExecutor;
using System;
using System.Collections.Generic;
using System.Text;
using MeatAppBackend.Executores.Restaurante;
using MeatAppBackend.Entidades;
using System.Threading.Tasks;

namespace MeatAppBackend.Testes.Executores.Restaurante
{
    [TestClass]
    public class ObterRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IRestauranteRepositorio> _restauranteRepositorio;
        private ObterRestauranteExecutor _obterRestauranteExecutor;
        #endregion

        #region Testes
        private void Inicializar(string restauranteId, RestauranteEntidade restaurante)
        {
            _restauranteRepositorio = RestauranteRepositorioConfiguracao.Instancia().ObterRestaurante(restauranteId, restaurante).Mock();
            _obterRestauranteExecutor = new ObterRestauranteExecutor(_restauranteRepositorio.Object);
        }
        [TestMethod]
        public void ObterRestauranteSemRetorno()
        {
            string restauranteId = "teste";
            RestauranteEntidade retorno = new RestauranteEntidade();

            Inicializar(restauranteId, retorno);

            var resposta = _obterRestauranteExecutor.Executar(new ObterRestauranteRequisicao());

            Assert.IsNull(resposta.Restaurante);
        }

        [TestMethod]
        public void ObterRestauranteComRetorno()
        {
            string restauranteId = "burguer-house";
            RestauranteEntidade retorno = new RestauranteEntidade()
            {
                Id = restauranteId,
                Nome = "",
                Categoria = "",
                TempoEntrega = "",
                Avaliacao = 0,
                Imagem = "",
                Sobre = "",
                Funcionamento = ""
            };

            Inicializar(restauranteId, retorno);

            var requisicao = new ObterRestauranteRequisicao()
            {
                RestaurantId = restauranteId
            };
            var resposta =  _obterRestauranteExecutor.Executar(requisicao);

            Assert.IsNotNull(resposta.Restaurante);
        }

        #endregion
    }
}
