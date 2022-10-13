using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CRB.Rates.Client.Model {

  /// <summary>
  /// Информация о валюте.
  /// </summary>
  [DataContract]
  public class CurrencyResponse {
    /// <summary>
    /// ISO Букв. код валюты.
    /// </summary>
    /// <value>ISO Букв. код валюты.</value>
    [DataMember(Name="alphaCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "alphaCode")]
    public string AlphaCode { get; set; }

    /// <summary>
    /// Название валюты
    /// </summary>
    /// <value>Название валюты</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// ISO Цифр. код валюты
    /// </summary>
    /// <value>ISO Цифр. код валюты</value>
    [DataMember(Name="numericCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numericCode")]
    public string NumericCode { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CurrencyResponse {\n");
      sb.Append("  AlphaCode: ").Append(AlphaCode).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  NumericCode: ").Append(NumericCode).Append("\n");
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
