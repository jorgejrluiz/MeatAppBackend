
using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarAvaliacaoRestauranteRequisicao;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Restaurante
{
    public class AlterarAvaliacaoRestauranteExecutor : IExecutorSemResultado<AlterarAvaliacaoRestauranteRequisicao>
    {
        private readonly IRestauranteRepositorio restauranteRepositorio;

        public AlterarAvaliacaoRestauranteExecutor(IRestauranteRepositorio restauranteRepositorio)
        {
            this.restauranteRepositorio = restauranteRepositorio;

        }

        public void Executar(AlterarAvaliacaoRestauranteRequisicao requisicao)
        {
            restauranteRepositorio.AlterarAvaliacaoRestaurante(requisicao.restauranteID, requisicao.Avaliacao);
        }
        public void ValidarCampos(AlterarAvaliacaoRestauranteRequisicao requisicao)
        {
            if(requisicao != null)
            {
                if(requisicao.restauranteID == null)
                {
                    throw new BaseException("Informe o ID do restaurante", HttpStatusCode.BadRequest);
                }
                else if (requisicao.Avaliacao.ToString() == null)
                {
                    throw new BaseException("Informe o nome do restaurante", HttpStatusCode.BadRequest);
                }
            }
        }   
    }
}
