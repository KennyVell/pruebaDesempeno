using System.Net;
using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Services.Quotes;

namespace pruebaDesempeno.Controllers.Quotes
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class QuotesUpdateController : ControllerBase
    {
        private readonly IQuotesRepository _repository;
        public QuotesUpdateController(IQuotesRepository repository)
        {
            _repository = repository;
        }

        [HttpPut]
        [Route("api/quotes/{id}")]
        public async Task<IActionResult> UpdateCita(int id, [FromBody] QuoteDTO quote)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest("The quote fields cannot be null.");
            } */
            if (quote == null)
            {
                return BadRequest("The quote fields are invalid.");
            }

            try
            {
                var (result, message, statusCode) = await _repository.Update(id, quote);
                if (statusCode == HttpStatusCode.OK)
                {
                    return Ok(result);
                }
                else if (statusCode == HttpStatusCode.NotFound)
                {
                    return NotFound(message);
                }
                else
                {
                    return StatusCode((int)statusCode, message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating the quote: {ex.Message}");
            }
        }

    }
}