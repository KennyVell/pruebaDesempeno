

using pruebaDesempeno.Models;

namespace pruebaDesempeno.Services.MailerSend
{
    public class EmailSender : IEmailSender
    {
        private readonly HttpClient _httpClient;
        private readonly string? _ApiUrl;
        private readonly string? _ApiKey;
        private readonly string? _fromEmail;

        public EmailSender(HttpClient httpClient, IConfiguration configuration){
            _ApiKey = configuration["MailerSend:ApiKey"];
            _ApiUrl = configuration["MailerSend:ApiUrl"];
            _fromEmail = configuration["MailerSend:FromEmail"];
            _httpClient = httpClient;   
        }
        public async Task<string> SendEmail(Quote quote, string toEmail)
        {
            var request = new{
                from = new {email = _fromEmail},
                to = new {email = toEmail},
                subject = "Quote created",
                text = $"A new quote has been created, the date is: {quote.Date}"
            };

            //Token configuration
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _ApiKey);

            try
            {
                var response = await _httpClient.PostAsJsonAsync(_ApiUrl, request);
                response.EnsureSuccessStatusCode();

                return "Quote sent successfully";
            }

            catch (HttpRequestException ex)
            {
                return "Error: " + ex.Message;
                throw new ApplicationException("Error sending the mail");
            }
        }
    }
}