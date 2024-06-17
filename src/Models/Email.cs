using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MailerSendApi.Models
{
  public class Email
  {
    // Say to copiler that this field most be parse as "from"
    // [Required]
    // [JsonPropertyName("from")]
    // public Recipent? From {get; set;}

    [Required]
    [JsonProperty("to")]
    public Recipent[] To {get; set;}

    [Required]
    [JsonProperty("subject")]
    public string Subject {get; set;}

    [JsonProperty("text")]
    public string? Text {get; set;}

    [JsonProperty("html")]
    public string? Html {get; set;}
  }
}