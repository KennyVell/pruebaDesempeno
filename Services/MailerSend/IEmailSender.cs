using pruebaDesempeno.Models;

namespace pruebaDesempeno.Services.MailerSend
{
    public interface IEmailSender
    {
        Task<string> SendEmail(Quote quote, string toEmail);
    }
}