using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Services.Pets;

namespace pruebaDesempeno.Controllers.Pets
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class PetsOwnerListController : ControllerBase
    {
        private readonly IPetsRepository _repository;
        public PetsOwnerListController(IPetsRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("api/pets/{id}/owners")]
        public async Task<IActionResult> GetByOwnerId(int id)
        {
            try
            {
                var (result,message,statusCode) = await _repository.GetByOwnerId(id);
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

    }
}