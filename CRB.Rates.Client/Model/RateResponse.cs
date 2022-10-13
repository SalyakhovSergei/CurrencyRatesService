using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CRB.Rates.Client.Model {

  /// <summary>
  /// Информация о курсе валюты на заданную дату.
  /// </summary>
  [DataContract]
  public class RateResponse {
    /// <summary>
    /// Gets or Sets Currency
    /// </summary>
    [DataMember(Name="currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency")]
    public CurrencyResponse Currency { get; set; }

    /// <summary>
    /// Значение курса.
    /// </summary>
    /// <value>Значение курса.</value>
    [DataMember(Name="price", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// Номинал.
    /// </summary>
    /// <value>Номинал.</value>
    [DataMember(Name="scale", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "scale")]
    public int? Scale { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RateResponse {\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
      sb.Append("  Price: ").Append(Price).Append("\n");
      sb.Append("  Scale: ").Append(Scale).Append("\n");
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
