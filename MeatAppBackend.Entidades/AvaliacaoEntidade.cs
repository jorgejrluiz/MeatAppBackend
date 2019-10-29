using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Entidades
{
    public class AvaliacaoEntidade
    {
        public string Nome { get; set; }
        public string Data { get; set; }
        public double Nota { get; set; }
        public string Comentario { get; set; }
        public string RestauranteID { get; set; }
    }
}
