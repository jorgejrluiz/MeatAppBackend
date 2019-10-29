using System;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Executores.Avaliacao.ObterAvaliacaoExecutor;
using MeatAppBackend.Fronteiras.Executores.Restaurante.ObterRestauranteExecutor;

namespace MeatAppBackend.Executores.Avaliacao
{
    public class ObterAvaliacaoExecutor : IExecutor<ObterAvaliacaoRequisicao, ObterAvaliacaoResultado>
    {
        private readonly IAvaliacaoRepositorio avaliacaoRepositorio;

        public ObterAvaliacaoExecutor(IAvaliacaoRepositorio avaliacaoRepositorio)
        {
            this.avaliacaoRepositorio = avaliacaoRepositorio;

        }

        public ObterAvaliacaoResultado Executar(ObterAvaliacaoRequisicao requisicao)
        {
            return new ObterAvaliacaoResultado()
            {
                Avaliacao = avaliacaoRepositorio.ObterAvaliacao(requisicao.RestaurantId)
            };
        }
    }
}
