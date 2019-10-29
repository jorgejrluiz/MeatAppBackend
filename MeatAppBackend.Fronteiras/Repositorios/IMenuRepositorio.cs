using System;
using System.Collections.Generic;
using System.Text;
using MeatAppBackend.Entidades;

namespace MeatAppBackend.Fronteiras.Repositorios
{
    public interface IMenuRepositorio
    {
        IEnumerable<MenuEntidade> ListarMenuRestaurante();
        IEnumerable<MenuEntidade> ObterMenuRestaurante(string RestauranteId);
        MenuEntidade ObterPratoMenu(string Id);
        void InserirMenuRestaurante(MenuEntidade Menu);
        void ExcluirMenuRestaurante(String Id);

        void AlterarPrecoMenu(String Id, double preco);

        void AlterarMenu(MenuEntidade Menu);
    }
}
