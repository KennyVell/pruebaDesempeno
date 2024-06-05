using Microsoft.EntityFrameworkCore;
using pruebaDesempeno.Data;
using pruebaDesempeno.Models;
using pruebaDesempeno.DTOs;
using System.Net;

namespace pruebaDesempeno.Services.Vets
{
    public class VetsRepository : IVetsRepository
    {
        private readonly VeterinaryContext _context;
        public VetsRepository(VeterinaryContext context)
        {
            _context = context;
        }

        // ********All lines of code that are commented out are not required by the system but may be implemented in the future.********
        
        /* public async Task<(Vet vet, string message, HttpStatusCode statusCode)> Add(VetDTO vet)
        {
            if (vet.Name == null || vet.Email == null || vet.Address == null || vet.Phone == null || vet.ExperienceYears.HasValue)
            {
                return (null, "All fields are required.", HttpStatusCode.BadRequest);
            }
            var newVet = new Vet
            {
                Name = vet.Name,
                Email = vet.Email,
                Address = vet.Address,
                Phone = vet.Phone,
                ExperienceYears = vet.ExperienceYears.Value
            };
            await _context.Vets.AddAsync(newVet);
            await _context.SaveChangesAsync();
            return (newVet, "Veterinary created correctly", HttpStatusCode.Created);
        } */

        public async Task<(IEnumerable<Vet> vets, string message, HttpStatusCode statusCode)> GetAll()
        {
            var vets = await _context.Vets.ToListAsync();
            if (vets.Any())
                return (vets, "Veterinarians successfully obtained", HttpStatusCode.OK);
            else
                return (null, "Veterinarians not found!", HttpStatusCode.NotFound);
        }

        public async Task<(Vet vet, string message, HttpStatusCode statusCode)> GetById(int id)
        {
            var vet = await _context.Vets.FirstOrDefaultAsync(p => p.Id == id);
            if (vet != null)
                return (vet, "Veterinary successfully obtained", HttpStatusCode.OK);
            else
                return (null, $"Veterinary not found with ID {id}!", HttpStatusCode.NotFound);
        }

        /* public async Task<(Vet vet, string message, HttpStatusCode statusCode)> Update(int id, VetDTO vetUpdate)
        {
            var vet = await _context.Vets.FindAsync(id);
            if (vet == null)
            {
                return (null, "Veterinary not found!", HttpStatusCode.NotFound);
            }

            // Update required fields only if not null
            if (!string.IsNullOrEmpty(vetUpdate.Name))
            {
                vet.Name = vetUpdate.Name;
            }
            if (!string.IsNullOrEmpty(vetUpdate.Email))
            {
                vet.Email = vetUpdate.Email;
            }
            if (!string.IsNullOrEmpty(vetUpdate.Address))
            {
                vet.Address = vetUpdate.Address;
            }
            if (!string.IsNullOrEmpty(vetUpdate.Phone))
            {
                vet.Phone = vetUpdate.Phone;
            }
            if (vetUpdate.ExperienceYears.HasValue)
            {
                vet.ExperienceYears = vetUpdate.ExperienceYears.Value;
            }

            _context.Entry(vet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (vet, "Veterinary updated correctly", HttpStatusCode.OK);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _context.Vets.AnyAsync(u => u.Email == email);
        } */
    }
}