using MeatAppBackend.Fronteiras.Executores.Restaurante.ExcluirRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Executores.Restaurante
{
    public class ExcluirRestauranteExecutor : IExecutorSemResultado<ExcluirRestauranteRequisicao>
    {
        private readonly IRestauranteRepositorio restauranteRepositorio;

        public ExcluirRestauranteExecutor(IRestauranteRepositorio restauranteRepositorio)
        {
            this.restauranteRepositorio = restauranteRepositorio;

        }
        public void Executar(ExcluirRestauranteRequisicao requisicao)
        {   
            restauranteRepositorio.ExcluirRestaurante(requisicao.RestaurantId);
        }
    }
}
