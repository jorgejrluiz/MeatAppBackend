using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeatAppBackend.Api.Models
{
    public class AvaliacaoModel
    {
        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("date")]
        public string Data { get; set; }

        [JsonProperty("rating")]
        public double Nota { get; set; }

        [JsonProperty("comments")]
        public string Comentario { get; set; }

        [JsonProperty("restaurantId")]
        public string RestauranteID { get; set; }
    }
}
