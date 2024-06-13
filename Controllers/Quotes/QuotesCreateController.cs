using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Services.Quotes;
using pruebaDesempeno.Services.MailerSend;


namespace pruebaDesempeno.Controllers.Quotes
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class QuotesCreateController : ControllerBase
    {
        private readonly IQuotesRepository _repository;
        private readonly IEmailSender _mailRepository;
        public QuotesCreateController(IQuotesRepository repository, IEmailSender emailRepository)
        {
            _repository = repository;
            _mailRepository = emailRepository;
        }

        [HttpPost]
        [Route("api/quotes")]
        public async Task<IActionResult> Add([FromBody]QuoteDTO quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The quote fields cannot be null.");
            }

            try
            {
                var (result, message, statusCode) = await _repository.Add(quote);
                if (statusCode == HttpStatusCode.Created)
                {
                    await _mailRepository.SendEmail(result, "kenneth.geme1@gmail.com");
                    return CreatedAtAction(nameof(QuotesController.GetById), "Quotes", new { id = result.Id }, result);
                }
                else
                {
                    return StatusCode((int)statusCode, message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating the quote: {ex.Message}");
            }
        }

    }
}