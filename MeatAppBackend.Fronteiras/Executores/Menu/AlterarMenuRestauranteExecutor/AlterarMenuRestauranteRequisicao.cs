﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Fronteiras.Executores.Menu.AlterarMenuRestauranteExecutor
{
    public class AlterarMenuRestauranteRequisicao
    {
        public string Id { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string RestauranteID { get; set; }
    }
}
