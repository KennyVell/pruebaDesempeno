

namespace pruebaDesempeno.Services.MailerSend
{
    public class EmailSender : IEmailSender
    {
        private readonly HttpClient _httpClient;
        private readonly string? _ApiKey;
        private readonly string? _fromEmail;

        public EmailSender(HttpClient httpClient, IConfiguration configuration){
            _ApiKey = configuration["MailerSend:ApiKey"];
            _fromEmail = configuration["MailerSend:FromEmail"];
            _httpClient = httpClient;   
        }
        public async Task<string> SendEmail(string info, string toEmail)
        {
            throw new NotImplementedException();
        }
    }
}