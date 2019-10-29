using MeatAppBackend.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeatAppBackend.Fronteiras.Executores.Menu.ObterRestauranteExecutor
{
    public class ObterMenuRestauranteResultado
    {
       public IEnumerable<MenuEntidade> Menu { get; set; }
    }
}
