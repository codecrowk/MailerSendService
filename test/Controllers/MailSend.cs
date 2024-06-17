using MailerSendApi;
using MailerSendApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApi.Controllers
{
  [Route("api/emails")]
  [ApiController]
  public class MailerSendController: ControllerBase
  {
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
        // From = new Recipent{Email = "dannyKentala@trial-jy7zpl9xp8ol5vx6.mlsender.net"},
        To = 
        [
          new Recipent{Email = "handres41@outlook.com"}
        ],
        Subject = "Email from backend",
        Html = "This is an email generate from backend, but with Library"
      };

      // MailerSendService mailerSendService = new MailerSendService();
      string emailInfo = await _mailerSendService.SendEmail(newEmail);
      return emailInfo;
    }
  }
}