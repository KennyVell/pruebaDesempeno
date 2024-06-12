
namespace pruebaDesempeno.Services.MailerSend
{
    public interface IEmailSender
    {
        Task<string> SendEmail(string info, string toEmail);
    }
}