using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CRB.Rates.Client.Model {

  /// <summary>
  /// Сообщение об ошибке, возникшей в сервисе курсов валют.
  /// </summary>
  [DataContract]
  public class GlobalErrorResponse {
    /// <summary>
    /// Код состояния HTTP.
    /// </summary>
    /// <value>Код состояния HTTP.</value>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public int? Status { get; set; }

    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    /// <value>Сообщение об ошибке.</value>
    [DataMember(Name="message", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; }

    /// <summary>
    /// Дата и время возникновения ошибки.
    /// </summary>
    /// <value>Дата и время возникновения ошибки.</value>
    [DataMember(Name="timestamp", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "timestamp")]
    public string Timestamp { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GlobalErrorResponse {\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  Message: ").Append(Message).Append("\n");
      sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
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
