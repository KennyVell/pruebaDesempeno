using System.Net;
using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Services.Pets;

namespace pruebaDesempeno.Controllers.Pets
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class PetsCreateController : ControllerBase
    {
        private readonly IPetsRepository _repository;
        public PetsCreateController(IPetsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("api/pets")]
        public async Task<IActionResult> AddCita([FromBody] PetDTO pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The pet fields cannot be null.");
            }

            try
            {
                var (result, message, statusCode) = await _repository.Add(pet);
                if (statusCode == HttpStatusCode.Created)
                {
                    return CreatedAtAction(nameof(PetsController.GetById), "Pets", new { id = result.Id }, result);
                }
                else
                {
                    return StatusCode((int)statusCode, message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating the pet: {ex.Message}");
            }
        }

    }
}