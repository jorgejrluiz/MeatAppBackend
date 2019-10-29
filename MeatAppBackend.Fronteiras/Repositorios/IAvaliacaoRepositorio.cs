using System;
using System.Collections.Generic;
using System.Text;
using MeatAppBackend.Entidades;

namespace MeatAppBackend.Fronteiras.Repositorios
{
    public interface IAvaliacaoRepositorio
    {
        IEnumerable<AvaliacaoEntidade> ListarAvaliacao();
        IEnumerable<AvaliacaoEntidade> ObterAvaliacao(string restaurantID);    
        void InserirAvaliacao(AvaliacaoEntidade avaliacao);
        void ExcluirAvaliacao(string avaliacaoId);
    }
}
