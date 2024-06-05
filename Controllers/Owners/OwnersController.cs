using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.Services.Owners;

namespace pruebaDesempeno.Controllers.Owners
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class OwnersController : ControllerBase
    {
        private readonly IOwnersRepository _repository;
        public OwnersController(IOwnersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/owners")]
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining owners: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("api/owners/{id}")]
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error obtaining the owner: {ex.Message}");
            }
        }

    }
}