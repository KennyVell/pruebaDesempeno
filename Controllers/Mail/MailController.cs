using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Models;
using pruebaDesempeno.Services.MailerSend;

namespace pruebaDesempeno.Controllers.Mail
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class MailController : ControllerBase
    {
        private readonly IEmailSender _repository;
        public MailController(IEmailSender repository)
        {
            _repository = repository;
        }

        /* [HttpPost]
        [Route("api/email/send")]
        public async Task<IActionResult> SendEmail([FromBody]string toEmail)
        {
            try
            {
                await _repository.SendEmail(toEmail);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error sending the email: {ex.Message}");
            }
        } */
    }
}