using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeatAppBackend.Api.Models
{
    public class PedidoModel
    {
        [JsonProperty("address")]
        public string Endereco { get; set; }
        [JsonProperty("number")]
        public int Numero { get; set; }
        [JsonProperty("optionalAddress")]
        public string EnderecoOpcional { get; set; }
        [JsonProperty("paymentOption")]
        public string FormaPagamento { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }



    }
}
