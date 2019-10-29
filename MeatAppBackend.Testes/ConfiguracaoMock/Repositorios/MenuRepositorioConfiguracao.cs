using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Repositorios;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Testes.ConfiguracaoMock.Repositorios
{
    public class MenuRepositorioConfiguracao
    {
        #region Propriedades
        private readonly Mock<IMenuRepositorio> mock = new Mock<IMenuRepositorio>();
        #endregion

        #region Construtores
        private MenuRepositorioConfiguracao() { }

        public static MenuRepositorioConfiguracao Instancia()
        {
            return new MenuRepositorioConfiguracao();
        }
        public Mock<IMenuRepositorio> Mock()
        {
            return mock;
        }

        public MenuRepositorioConfiguracao ObterMenuRestaurante(string restauranteId, IEnumerable<MenuEntidade> retorno)
        {
            mock.Setup(m => m.ObterMenuRestaurante(restauranteId)).Returns(retorno);
            return this;
        }
        public MenuRepositorioConfiguracao ObterPratoMenu(string Id, MenuEntidade retorno)
        {
            mock.Setup(m => m.ObterPratoMenu(Id)).Returns(retorno);
            return this;
        }

        public MenuRepositorioConfiguracao ListarMenuRestaurante(IEnumerable<MenuEntidade> retorno)
        {
            mock.Setup(m => m.ListarMenuRestaurante());
            return this;
        }

        public MenuRepositorioConfiguracao InserirMenuRestaurante(MenuEntidade menu)
        {
            mock.Setup(m => m.InserirMenuRestaurante(menu)).Verifiable();
            return this;
        }

        public MenuRepositorioConfiguracao ExcluirMenuRestaurante(string Id)
        {
            mock.Setup(m => m.ExcluirMenuRestaurante(Id)).Verifiable();
            return this;
        }

        public MenuRepositorioConfiguracao AlterarMenuRestaurante(MenuEntidade menu)
        {
            mock.Setup(m => m.AlterarMenu(menu)).Verifiable();
            return this;
        }

        public MenuRepositorioConfiguracao AlterarPrecoMenuRestaurante(string Id, double Preco)
        {
            mock.Setup(m => m.AlterarPrecoMenu(Id, Preco)).Verifiable();
            return this;
        }
        #endregion

    }
}
