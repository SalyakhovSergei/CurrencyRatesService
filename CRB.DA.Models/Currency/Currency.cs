using System;
using System.Data;
using Newtonsoft.Json;

namespace CRB.DA.Models
{
    public class Currency
    {
        [JsonProperty("currency")]
        public CurrencyData CurrencyData { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("scale")]
        public int Scale { get; set; }
        public DateTime Date { get; set; }
    }
}