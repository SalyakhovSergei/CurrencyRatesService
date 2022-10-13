using Newtonsoft.Json;

namespace CRB.DA.Models
{
    public class CurrencyData
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("numericCode")]
        public string NumericCode { get; set; }
        [JsonProperty("alphaCode")]
        public string AlphaCode { get; set; }

    }
}