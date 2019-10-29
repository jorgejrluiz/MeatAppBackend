using MeatAppBackend.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Fronteiras.Executores.Avaliacao.InserirAvaliacaoExecutor
{
    public class InserirAvaliacaoRequisicao
    {
        public string Nome { get; set; }
        public string Data { get; set; }
        public double Nota { get; set; }
        public string Comentario { get; set; }
        public string RestauranteID { get; set; }
    }
}
