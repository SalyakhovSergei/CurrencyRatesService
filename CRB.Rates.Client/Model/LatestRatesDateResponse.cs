using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CRB.Rates.Client.Model {

  /// <summary>
  /// Дата курсов валют ЦБ.
  /// </summary>
  [DataContract]
  public class LatestRatesDateResponse {
    /// <summary>
    /// Дата курсов валют.
    /// </summary>
    /// <value>Дата курсов валют.</value>
    [DataMember(Name="date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date")]
    public DateTime? Date { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LatestRatesDateResponse {\n");
      sb.Append("  Date: ").Append(Date).Append("\n");
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
