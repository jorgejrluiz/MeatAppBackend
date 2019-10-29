using MeatAppBackend.Fronteiras.Executores.Menu.ObterMenuRestauranteExecutor;
using MeatAppBackend.Fronteiras.Executores.Menu.ObterRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Executores.Menu
{
    public class ObterMenuRestauranteExecutor : IExecutor<ObterMenuRestauranteRequisicao, ObterMenuRestauranteResultado>
    {
        private readonly IMenuRepositorio menuRepositorio;

        public ObterMenuRestauranteExecutor(IMenuRepositorio menuRepositorio)
        {
            this.menuRepositorio = menuRepositorio;

        }

        public ObterMenuRestauranteResultado Executar(ObterMenuRestauranteRequisicao requisicao)
        {

            return new ObterMenuRestauranteResultado()
            {
                Menu = menuRepositorio.ObterMenuRestaurante(requisicao.RestaurantId)
            };
        }
    }
}
