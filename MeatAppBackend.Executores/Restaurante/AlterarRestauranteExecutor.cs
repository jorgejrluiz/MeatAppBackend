using MeatAppBackend.Entidades;
using MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarRestauranteExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Restaurante
{
    public class AlterarRestauranteExecutor : IExecutorSemResultado<AlterarRestauranteRequisicao>
    {
        private readonly IRestauranteRepositorio restauranteRepositorio;

        public AlterarRestauranteExecutor(IRestauranteRepositorio restauranteRepositorio)
        {
            this.restauranteRepositorio = restauranteRepositorio;

        }
        public void Executar(AlterarRestauranteRequisicao requisicao)
        {
            var restauranteUpdate = new RestauranteEntidade()
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
            ValidarCampos(restauranteUpdate); 
            restauranteRepositorio.AlterarRestaurante(restauranteUpdate);
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
