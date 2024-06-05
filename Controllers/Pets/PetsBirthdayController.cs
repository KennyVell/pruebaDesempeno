using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Services.Pets;

namespace pruebaDesempeno.Controllers.Pets
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class PetsBirthdayController : ControllerBase
    {
        private readonly IPetsRepository _repository;
        public PetsBirthdayController(IPetsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/pets/{date}/birthday")]
        public async Task<IActionResult> GetByBirthDate(DateTime date)
        {
            try
            {
                var (result,message,statusCode) = await _repository.GetByBirthDate(date);
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