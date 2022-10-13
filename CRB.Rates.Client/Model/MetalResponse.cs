using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CRB.Rates.Client.Model {

  /// <summary>
  /// Информация о цене металла на заданную дату.
  /// </summary>
  [DataContract]
  public class MetalResponse {
    /// <summary>
    /// Код по классификатору клиринговых валют
    /// </summary>
    /// <value>Код по классификатору клиринговых валют</value>
    [DataMember(Name="alphaCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "alphaCode")]
    public string AlphaCode { get; set; }

    /// <summary>
    /// Наименование драгоценного металла
    /// </summary>
    /// <value>Наименование драгоценного металла</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Цена в рублях за 1 грамм.
    /// </summary>
    /// <value>Цена в рублях за 1 грамм.</value>
    [DataMember(Name="price", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "price")]
    public decimal? Price { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MetalResponse {\n");
      sb.Append("  AlphaCode: ").Append(AlphaCode).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Price: ").Append(Price).Append("\n");
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
