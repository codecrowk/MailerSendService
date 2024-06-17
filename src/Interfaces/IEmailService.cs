using MailerSendApi.Models;

namespace MailerSendApi.Interfaces
{
  public interface IEmailService
  {
    Task<string> SendEmail (Email data);
  }
}