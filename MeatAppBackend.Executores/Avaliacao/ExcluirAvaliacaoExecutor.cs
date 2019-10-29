using MeatAppBackend.Fronteiras.Executores.Avaliacao.ExcluirAvaliacaoExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Executores.Avaliacao
{
    public class ExcluirAvaliacaoExecutor : IExecutorSemResultado<ExcluirAvaliacaoExecutor>
    {
        private readonly IAvaliacaoRepositorio avaliacaoRespositorio;

        public ExcluirAvaliacaoExecutor(IAvaliacaoRepositorio avaliacaoRespositorio)
        {
            this.avaliacaoRespositorio = avaliacaoRespositorio;
        }

        public void Executar(ExcluirAvaliacaoRequisicao requisicao)
        {
            avaliacaoRespositorio.ExcluirAvaliacao(requisicao.Id);
        }
    }
}
