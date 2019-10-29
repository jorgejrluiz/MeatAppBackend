using MeatAppBackend.Fronteiras.Executores.Menu.ExcluirMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Executores.Menu
{
    public class ExcluirMenuRestauranteExecutor : IExecutorSemResultado<ExcluirMenuRestauranteRequisicao>
    {
        private readonly IMenuRepositorio menuRepositorio;

        public ExcluirMenuRestauranteExecutor(IMenuRepositorio menuRepositorio)
        {
            this.menuRepositorio = menuRepositorio;
        }

        public void Executar(ExcluirMenuRestauranteRequisicao requisicao)
        {
            menuRepositorio.ExcluirMenuRestaurante(requisicao.Id);
        }
    }
}
