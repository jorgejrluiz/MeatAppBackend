using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Restaurante.InserirRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Restaurante
{
    public class InserirRestauranteExecutor : IExecutorSemResultado<InserirRestauranteRequisicao>
    {
        private readonly IRestauranteRepositorio restauranteRepositorio;

        public InserirRestauranteExecutor(IRestauranteRepositorio restauranteRepositorio)
        {
            this.restauranteRepositorio = restauranteRepositorio;

        }

        public void Executar(InserirRestauranteRequisicao requisicao)
        {
            RestauranteEntidade restaurante = restauranteRepositorio.ObterRestaurante(requisicao.Id);
            if(restaurante != null)
                throw new BaseException("Restaurante já cadastrado", HttpStatusCode.Conflict);

            var restauranteInsercao = new RestauranteEntidade()
            {
                Id = requisicao.Id,
                Nome = requisicao.Nome,
                Categoria = requisicao.Categoria,
                TempoEntrega = requisicao.TempoEntrega,
                Avaliacao = requisicao.Avaliacao,
                Imagem = requisicao.Imagem,
                Sobre = requisicao.Sobre,
                Funcionamento = requisicao.Funcionamento
            };
            ValidarCampos(restauranteInsercao);
            restauranteRepositorio.InserirRestaurante(restauranteInsercao); 
        }

        private void ValidarCampos(RestauranteEntidade restaurante)
        {
            if (String.IsNullOrWhiteSpace(restaurante.Nome))
                throw new BaseException("Informe o nome do restaurante", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(restaurante.Categoria))
                throw new BaseException("Informe a Categoria do restaurante", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(restaurante.TempoEntrega))
                throw new BaseException("Informe o Tempo de Entrega do restaurante", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace((restaurante.Avaliacao).ToString()))
                throw new BaseException("Informe a Avaliacao do restaurante", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(restaurante.Imagem))
                throw new BaseException("Informe a Imagem do restaurante", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(restaurante.Sobre))
                throw new BaseException("Informe a descrição do restaurante", HttpStatusCode.BadRequest);
            if (String.IsNullOrWhiteSpace(restaurante.Funcionamento))
                throw new BaseException("Informe o Horário de funcionamento do restaurante", HttpStatusCode.BadRequest);
        }
    }
}
