using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Services.Quotes;

namespace pruebaDesempeno.Controllers.Quotes
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class QuotesVetsListController : ControllerBase
    {
        private readonly IQuotesRepository _repository;
        public QuotesVetsListController(IQuotesRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("api/quotes/{id}/vets")]
        public async Task<IActionResult> GetByVetId(int id)
        {
            try
            {
                var (result,message,statusCode) = await _repository.GetByVetId(id);
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