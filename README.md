<!-- ## Controller example
```cs

using Microsoft.AspNetCore.Mvc;
using SchoolApi.Helpers;
using SchoolApi.Models.MailerSend;

namespace SchoolApi.Controllers
{
  [Route("api/emails")]
  [ApiController]
  public class MailerSendController: ControllerBase
  {
    [HttpGet]
    public async Task<string> GetAll()
    {
      Email newEmail = new Email
      {
        From = new Recipent{Email = "<email_name>@<domain_name>"},
        To = 
        [
          new Recipent{Email = "<recipent_email>"}
        ],
        Subject = "Email from backend",
        Html = "This is an email generate from backend, backend i'm loving it"
      };

      MailerSendClient mailerSendClient = new MailerSendClient();
      string emailInfo = await mailerSendClient.SendEmail(newEmail);
      return emailInfo;
    }
  }
}
``` -->
## Configuration

### appsettings.json
```json
"EmailServiceOptions": {
  "ApiEmail": "<email_name>@<domain_name>",
  "ApiToken": "<your_domain_token>",
  "ApiUrl": "https://api.mailersend.com/v1/email"
}
```

### Program.cs
```cs
//----- Libraries injection
builder.Services.AddScoped<MailerSendService>();
```

### Controller
```cs
using MailerSendApi;
using MailerSendApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApi.Controllers
{
  [Route("api/emails")]
  [ApiController]
  public class MailerSendController: ControllerBase
  {
    // Dependency injection of mailerSendService
    private readonly MailerSendService _mailerSendService;
    public MailerSendController(MailerSendService mailerSendService)
    {
      _mailerSendService = mailerSendService;
    }

    [HttpGet]
    public async Task<string> GetAll()
    {
      Email newEmail = new Email
      {
        To = 
        [
          new Recipent{Email = "<recipent_email>"}
        ],
        Subject = "Email from backend",
        Html = "This is an email generate from backend, but with Library"
      };

      string emailInfo = await _mailerSendService.SendEmail(newEmail);
      return emailInfo;
    }
  }
}
```