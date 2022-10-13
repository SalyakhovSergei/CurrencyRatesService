using System;
using Newtonsoft.Json;

namespace CRB.DA.Models
{
    public class Metall
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("alphaCode")]
        public string AlphaCode { get; set; }
        public DateTimeOffset Date { get; set; }

    }
}