namespace MailerSendApi.Models
{
  public class EmailServiceOptions
  {
    /*
      ## Why mail here
      Because in free acounts you can only have one domain, so is no necessary to give this value dinamically
    */
    public string ApiEmail {get; set;}
    public string ApiToken {get; set;}
    public string ApiUrl {get; set;}
  }
}