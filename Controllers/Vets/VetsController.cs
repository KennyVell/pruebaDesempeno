using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Services.Vets;

namespace pruebaDesempeno.Controllers.Vets
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class VetsController : ControllerBase
    {
        private readonly IVetsRepository _repository;
        public VetsController(IVetsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/vets")]
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining veterinarians: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("api/vets/{id}")]
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining the veterinarians: {ex.Message}");
            }
        }

    }
}