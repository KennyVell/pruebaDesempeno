using System.Net;
using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Services.Quotes;

namespace pruebaDesempeno.Controllers.Quotes
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class QuotesCreateController : ControllerBase
    {
        private readonly IQuotesRepository _repository;
        public QuotesCreateController(IQuotesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("api/quotes/create")]
        public async Task<IActionResult> AddCita([FromBody] QuoteDTO quote)
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