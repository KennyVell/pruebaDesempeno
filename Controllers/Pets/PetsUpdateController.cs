using System.Net;
using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Services.Pets;

namespace pruebaDesempeno.Controllers.Pets
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class PetsUpdateController : ControllerBase
    {
        private readonly IPetsRepository _repository;
        public PetsUpdateController(IPetsRepository repository)
        {
            _repository = repository;
        }

        [HttpPut]
        [Route("api/pets/update/{id}")]
        public async Task<IActionResult> UpdateCita(int id, [FromBody] PetDTO pet)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest("The pet fields cannot be null.");
            } */
            if (pet == null)
            {
                return BadRequest("The pet fields are invalid.");
            }

            try
            {
                var (result, message, statusCode) = await _repository.Update(id, pet);
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating the pet: {ex.Message}");
            }
        }

    }
}