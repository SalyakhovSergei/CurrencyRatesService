using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CRB.Rates.Client.Model {

  /// <summary>
  /// Список официальных курсов валют на заданную дату, устанавливаемых ежедневно.
  /// </summary>
  [DataContract]
  public class RatesOnDateResponse {
    /// <summary>
    /// Дата установления курса (может отличатся от запрашиваемой если на запрашиваемою дату курс не устанавливался).
    /// </summary>
    /// <value>Дата установления курса (может отличатся от запрашиваемой если на запрашиваемою дату курс не устанавливался).</value>
    [DataMember(Name="date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date")]
    public DateTime? Date { get; set; }

    /// <summary>
    /// Список курсов валют.
    /// </summary>
    /// <value>Список курсов валют.</value>
    [DataMember(Name="rates", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rates")]
    public List<RateResponse> Rates { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RatesOnDateResponse {\n");
      sb.Append("  Date: ").Append(Date).Append("\n");
      sb.Append("  Rates: ").Append(Rates).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
