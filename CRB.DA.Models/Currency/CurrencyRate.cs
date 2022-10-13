using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CRB.DA.Models
{
    public class CurrencyRate
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("rates")]
        public List<Currency> Rates { get; set; }
    }
}