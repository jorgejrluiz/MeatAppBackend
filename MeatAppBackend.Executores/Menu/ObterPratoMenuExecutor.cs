using MeatAppBackend.Fronteiras.Executores.Menu;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Executores.Menu
{
    public class ObterPratoMenuExecutor : IExecutor<ObterPratoMenuRequisicao, ObterPratoMenuResultado>
    {
        private readonly IMenuRepositorio menuRepositorio;

        public ObterPratoMenuExecutor(IMenuRepositorio menuRepositorio)
        {
            this.menuRepositorio = menuRepositorio;

        }
        public ObterPratoMenuResultado Executar(ObterPratoMenuRequisicao requisicao)
        {
            return new ObterPratoMenuResultado()
            {
                Menu = menuRepositorio.ObterPratoMenu(requisicao.Id)
            };
        }
    }
}
