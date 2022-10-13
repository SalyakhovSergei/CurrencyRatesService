using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CRB.DA.Models
{
    public class MetallRate
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("prices")]
        public List<Metall> Rates { get; set; }
    }
}