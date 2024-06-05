using System.Net;
using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Services.Owners;

namespace pruebaDesempeno.Controllers.Owners
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class OwnersUpdateController : ControllerBase
    {
        private readonly IOwnersRepository _repository;
        public OwnersUpdateController(IOwnersRepository repository)
        {
            _repository = repository;
        }

        [HttpPut]
        [Route("api/owners/update/{id}")]
        public async Task<IActionResult> UpdateCita(int id, [FromBody] OwnerDTO owner)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest("The owner fields cannot be null.");
            } */
            if (owner == null)
            {
                return BadRequest("The owner fields are invalid.");
            }

            try
            {
                var (result, message, statusCode) = await _repository.Update(id, owner);
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating the owner: {ex.Message}");
            }
        }

    }
}