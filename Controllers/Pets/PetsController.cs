using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Services.Pets;

namespace pruebaDesempeno.Controllers.Pets
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class PetsController : ControllerBase
    {
        private readonly IPetsRepository _repository;
        public PetsController(IPetsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/pets")]
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining pets: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("api/pets/{id}")]
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining the pet: {ex.Message}");
            }
        }

    }
}