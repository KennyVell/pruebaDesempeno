using System.Net;
using Microsoft.AspNetCore.Mvc;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Services.Owners;

namespace pruebaDesempeno.Controllers.Owners
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class OwnersCreateController : ControllerBase
    {
        private readonly IOwnersRepository _repository;
        public OwnersCreateController(IOwnersRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("api/owners/create")]
        public async Task<IActionResult> AddCita([FromBody] OwnerDTO owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The owner fields cannot be null.");
            }

            if (!await _repository.IsEmailUniqueAsync(owner.Email))
            {   
                return BadRequest("E-mail is already in use.");
            }

            try
            {
                var (result, message, statusCode) = await _repository.Add(owner);
                if (statusCode == HttpStatusCode.Created)
                {
                    return CreatedAtAction(nameof(OwnersController.GetById), "Owners", new { id = result.Id }, result);
                }
                else
                {
                    return StatusCode((int)statusCode, message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating the owner: {ex.Message}");
            }
        }

    }
}