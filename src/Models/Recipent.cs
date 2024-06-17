using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MailerSendApi.Models
{
  public class Recipent
  {
    [JsonProperty("email")]
    public string Email {get; set;}

    [JsonProperty("name")]
    public string? Name {get; set;}
  }
}