using MeatAppBackend.Entidades;
using MeatAppBackend.Executores.Restaurante;
using MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarRestauranteExecutor;
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
    public class AlterarRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IRestauranteRepositorio> _restauranteRepositorio;
        private AlterarRestauranteExecutor _alterarRestauranteExecutor;
        #endregion

        #region
        private void Inicializar(RestauranteEntidade restaurante)
        {
            _restauranteRepositorio = RestauranteRepositorioConfiguracao.Instancia().AlterarRestaurante(restaurante).Mock();
            _alterarRestauranteExecutor = new AlterarRestauranteExecutor(_restauranteRepositorio.Object);
        }

        [TestMethod]
        public void AlterarRestaurante()
        {
            var restaurante = new RestauranteEntidade
            {
                Id = "starbucks",
                Nome = "Starbucks",
                Categoria = "Cafe",
                TempoEntrega = "10 a 30 m",
                Avaliacao = 4,
                Imagem = "teste",
                Sobre = "teste",
                Funcionamento = "24 horas"
            };
            var requisicao = new AlterarRestauranteRequisicao
            {
                Id = restaurante.Id,
                Nome = restaurante.Nome,
                Categoria = restaurante.Categoria,
                TempoEntrega = restaurante.TempoEntrega,
                Avaliacao = restaurante.Avaliacao,
                Imagem = restaurante.Imagem,
                Sobre = restaurante.Sobre,
                Funcionamento = restaurante.Funcionamento
            };
            Inicializar(restaurante);

            _alterarRestauranteExecutor.Executar(requisicao);
        }
        #endregion
    }
}
