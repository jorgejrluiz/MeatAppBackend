using System;
using System.Collections.Generic;
using System.Text;
using MeatAppBackend.Entidades;
namespace MeatAppBackend.Fronteiras.Executores.Avaliacao.ObterAvaliacaoExecutor
{
    public class ObterAvaliacaoResultado
    {
        public IEnumerable<AvaliacaoEntidade> Avaliacao { get; set; }
    }
}
