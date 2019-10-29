using MeatAppBackend.Entidades;
using MeatAppBackend.Executores.Restaurante;
using MeatAppBackend.Fronteiras.Executores.Restaurante.InserirRestauranteExecutor;
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
    public class InserirRestauranteExecutorTeste
    {
        #region Propriedades
        private Mock<IRestauranteRepositorio> _restauranteRepositorio;
        private InserirRestauranteExecutor _inserirRestauranteExecutor;
        #endregion

        #region
        private void Inicializar(RestauranteEntidade restaurante)
        {
            _restauranteRepositorio = RestauranteRepositorioConfiguracao.Instancia().InserirRestaurante(restaurante).Mock();
            _inserirRestauranteExecutor = new InserirRestauranteExecutor(_restauranteRepositorio.Object);
        }

        [TestMethod]
         public void InserirRestaurante()
        {
            var restaurante = new RestauranteEntidade
            {
                Id = "Teste",
                Nome = "Teste",
                Categoria = "Teste",
                TempoEntrega = "10 a 30 m",
                Avaliacao = 4,
                Imagem = "Teste",
                Sobre = "Teste",
                Funcionamento = "Teste"
            };
            var requisicao = new InserirRestauranteRequisicao
            {
                Id = "Teste",
                Nome = "Teste",
                Categoria = "Teste",
                TempoEntrega = "10 a 30 m",
                Avaliacao = 4,
                Imagem = "Teste",
                Sobre = "Teste",
                Funcionamento = "Teste"
            };
            Inicializar(restaurante);

            _inserirRestauranteExecutor.Executar(requisicao);
        }
        #endregion
    }
}
