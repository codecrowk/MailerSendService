## Controller example
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
```
