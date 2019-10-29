using MeatAppBackend.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Fronteiras.Executores.Restaurante.AlterarRestauranteExecutor
{
    public class AlterarRestauranteRequisicao
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string TempoEntrega { get; set; }
        public double Avaliacao { get; set; }
        public string Imagem { get; set; }
        public string Sobre { get; set; }
        public string Funcionamento { get; set; }
    }
}
