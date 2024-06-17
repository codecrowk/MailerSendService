using System.Text;
using MailerSendApi.Interfaces;
using MailerSendApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MailerSendApi
{
  public class MailerSendService: IEmailService
  {
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly EmailServiceOptions _options;
    private readonly IConfiguration _configuration;

    public MailerSendService (IConfiguration configuration)
    {
      _configuration = configuration.GetSection(nameof(EmailServiceOptions));
      _options = new EmailServiceOptions()
      {
        ApiToken = _configuration["ApiToken"],
        ApiEmail = _configuration["ApiEmail"],
        ApiUrl = _configuration["ApiUrl"]
      };
    }

    public async Task<string> SendEmail(Email data)
    {
      using HttpResponseMessage response = await PostEmail(data);
      return await response.Content.ReadAsStringAsync();
    }

    private async Task<HttpResponseMessage> PostEmail (Email data)
    {
      /*
        ## We have to map **from** property
        Then pass it to the dataWithEmail object
      */
      string from = $"{{\"email\":\"{_options.ApiEmail}\"}}";

      JObject dataWithEmail = JObject.FromObject(data);
      dataWithEmail.Add("from", JObject.Parse(from));

      // Serialize email information
      StringContent content = new StringContent(dataWithEmail.ToString(Formatting.None), Encoding.UTF8, "application/json");
        
      _httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

      // Add Token
      _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiToken}");

      HttpResponseMessage response = await _httpClient.PostAsync(_options.ApiUrl, content);

      response.EnsureSuccessStatusCode();

      return response;
    }
  }
}
