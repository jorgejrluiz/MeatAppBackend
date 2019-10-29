using MeatAppBackend.Fronteiras.Executores.Menu.AlterarPrecoMenuExecutor;
using MeatAppBackend.Fronteiras.Repositorios;
using MeatAppBackend.Fronteiras.Shared;
using MeatAppBackend.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeatAppBackend.Executores.Menu
{
    public class AlterarPrecoMenuRestauranteExecutor : IExecutorSemResultado<AlterarPrecoMenuRequisicao>
    {
        private readonly IMenuRepositorio menuRepositorio;

        public AlterarPrecoMenuRestauranteExecutor(IMenuRepositorio menuRepositorio)
        {
            this.menuRepositorio = menuRepositorio;
        }

        public void Executar(AlterarPrecoMenuRequisicao requisicao)
        {
            ValidarCampos(requisicao);
            menuRepositorio.AlterarPrecoMenu(requisicao.Id, requisicao.Preco);
        }

        public void ValidarCampos(AlterarPrecoMenuRequisicao requisicao)
        {
            if (requisicao != null)
            {
                if (requisicao.Id == null)
                {
                    throw new BaseException("Informe o ID do restaurante", HttpStatusCode.BadRequest);
                }
                else if (requisicao.Preco.ToString() == null)
                {
                    throw new BaseException("Informe o nome do restaurante", HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
