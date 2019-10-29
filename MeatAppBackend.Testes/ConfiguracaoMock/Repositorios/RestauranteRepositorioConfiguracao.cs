using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Entidades;

namespace MeatAppBackend.Testes.ConfiguracaoMock.Repositorios
{
    public class RestauranteRepositorioConfiguracao
    {
        #region Propriedades
        private readonly Mock<IRestauranteRepositorio> mock = new Mock<IRestauranteRepositorio>();
        #endregion

        #region Construtores
        private RestauranteRepositorioConfiguracao() { }

        public static RestauranteRepositorioConfiguracao Instancia()
        {
            return new RestauranteRepositorioConfiguracao();
        }

        public Mock<IRestauranteRepositorio> Mock()
        {
            return mock;
        }

        public RestauranteRepositorioConfiguracao ObterRestaurante(string restauranteId, RestauranteEntidade retorno)
        {
            mock.Setup(m => m.ObterRestaurante(restauranteId)).Returns(retorno);
            return this;
        }

        public RestauranteRepositorioConfiguracao ListarRestaurante(IEnumerable<RestauranteEntidade> retorno)
        {
            mock.Setup(m => m.ListarRestaurantes());
            return this;
        }

        public RestauranteRepositorioConfiguracao InserirRestaurante(RestauranteEntidade restaurante)
        {
            mock.Setup(m => m.InserirRestaurante(restaurante)).Verifiable();
            return this;
        }

        public RestauranteRepositorioConfiguracao ExcluirRestaurante(string restauranteId)
        {
            mock.Setup(m => m.ExcluirRestaurante(restauranteId));
            return this;
        }

        public RestauranteRepositorioConfiguracao AlterarRestaurante(RestauranteEntidade restaurante)
        {
            mock.Setup(m => m.AlterarRestaurante(restaurante)).Verifiable();
            return this;
        }

        public RestauranteRepositorioConfiguracao AlterarAvaliacaoRestaurante(string restauranteId, double Avaliacao)
        {
            mock.Setup(m => m.AlterarAvaliacaoRestaurante(restauranteId, Avaliacao)).Verifiable();
            return this;
        }
        #endregion
    }
}
