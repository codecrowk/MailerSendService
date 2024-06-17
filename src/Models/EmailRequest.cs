using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MailerSendApi.Models
{
  public class EmailRequest: Email
  {
    // Say to copiler that this field most be parse as "from"
    [Required]
    [JsonPropertyName("from")]
    public Recipent? From {get; set;}
  }
}