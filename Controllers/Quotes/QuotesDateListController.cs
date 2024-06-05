using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Services.Quotes;

namespace pruebaDesempeno.Controllers.Quotes
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class QuotesDateListController : ControllerBase
    {
        private readonly IQuotesRepository _repository;
        public QuotesDateListController(IQuotesRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("api/quotes/{date}/date")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            try
            {
                var (result,message,statusCode) = await _repository.GetByDate(date);
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

    }
}