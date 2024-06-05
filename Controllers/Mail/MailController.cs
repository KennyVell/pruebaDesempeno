/* using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Models;

namespace pruebaDesempeno.Controllers.Mail
{
    public class MailController
    {
        public async void EnviarCorreo()
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";

                string jwtToken = "mlsn.7572a9a042404d39892ce30e364b16a1831836f8bb067b3946e4757bc43fca19";

                var emailMessage = new Email
                {
                    from = new From { email = "test@example.com"},
                    to = new []
                    {
                        new To { email = "kenneth.geme1@gmail.com" }
                    },
                    subject = "Your pet need attention",
                    text = "from the veterinary your pet need attention",
                    html = "Your pet need attention"
                };

                string jsonBody = JsonSerializer.Serialize(emailMessage);

                using (HttpClient client = new HttpClient())

            }
        }
    }
} */