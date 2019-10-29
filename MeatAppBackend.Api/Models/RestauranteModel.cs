using Newtonsoft.Json;

namespace MeatAppBackend.Api.Models
{
    public class RestauranteModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Nome { get; set; }
        [JsonProperty("category")]
        public string Categoria { get; set; }
        [JsonProperty("deliveryEstimate")]
        public string TempoEntrega { get; set; }
        [JsonProperty("rating")]
        public double Avaliacao { get; set; }
        [JsonProperty("imagePath")]
        public string Imagem { get; set; }
        [JsonProperty("about")]
        public string Sobre { get; set; }
        [JsonProperty("hours")]
        public string Funcionamento { get; set; }
    }
}
