using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Avaliacao.InserirAvaliacaoExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Avaliacao
{
    public class InserirAvaliacaoExecutor : IExecutorSemResultado<InserirAvaliacaoRequisicao>
    {
        private readonly IAvaliacaoRepositorio avaliacaoRepositorio;
        private readonly IRestauranteRepositorio restauranteRepositorio;

        public InserirAvaliacaoExecutor(IAvaliacaoRepositorio avaliacaoRepositorio, IRestauranteRepositorio restauranteRepositorio)
        {
            this.avaliacaoRepositorio = avaliacaoRepositorio;
            this.restauranteRepositorio = restauranteRepositorio;
        }
        public void Executar(InserirAvaliacaoRequisicao requisicao)
        {
            RestauranteEntidade restaurante = restauranteRepositorio.ObterRestaurante(requisicao.RestauranteID);
            if (restaurante == null)
                throw new BaseException("Restaurante não cadastrado", HttpStatusCode.Conflict);


            var avaliacaoInsercao = new AvaliacaoEntidade()
            {
                Nome = requisicao.Nome,
                Data = requisicao.Data,
                Nota = requisicao.Nota,
                Comentario = requisicao.Comentario,
                RestauranteID = requisicao.RestauranteID
            };
            avaliacaoRepositorio.InserirAvaliacao(avaliacaoInsercao);
        }
    }
}
