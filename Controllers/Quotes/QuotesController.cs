using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Services.Quotes;

namespace pruebaDesempeno.Controllers.Quotes
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesRepository _repository;
        public QuotesController(IQuotesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/quotes")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var (result,message,statusCode) = await _repository.GetAll();
                if(result == null)
                {
                    return NotFound(message);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining quotes: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("api/quotes/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var (result,message,statusCode) = await _repository.GetById(id);
                if(result == null)
                {
                    return NotFound(message);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining the quote: {ex.Message}");
            }
        }

    }
}