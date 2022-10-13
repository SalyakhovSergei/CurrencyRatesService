using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CRB.Rates.Client.Model {

  /// <summary>
  /// Список официальных цен драгоценных металлов на заданную дату
  /// </summary>
  [DataContract]
  public class MetalsOnDateResponse {
    /// <summary>
    /// Дата установления цены (может отличатся от запрашиваемой если на запрашиваемою дату курс не устанавливался).
    /// </summary>
    /// <value>Дата установления цены (может отличатся от запрашиваемой если на запрашиваемою дату курс не устанавливался).</value>
    [DataMember(Name="date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date")]
    public DateTime? Date { get; set; }

    /// <summary>
    /// Список цен драгоценных металлов.
    /// </summary>
    /// <value>Список цен драгоценных металлов.</value>
    [DataMember(Name="prices", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "prices")]
    public List<MetalResponse> Prices { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MetalsOnDateResponse {\n");
      sb.Append("  Date: ").Append(Date).Append("\n");
      sb.Append("  Prices: ").Append(Prices).Append("\n");
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
