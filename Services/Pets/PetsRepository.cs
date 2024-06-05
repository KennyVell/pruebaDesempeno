using Microsoft.EntityFrameworkCore;
using pruebaDesempeno.Data;
using pruebaDesempeno.Models;
using pruebaDesempeno.DTOs;
using System.Net;

namespace pruebaDesempeno.Services.Pets
{
    public class PetsRepository : IPetsRepository
    {
        private readonly VeterinaryContext _context;
        public PetsRepository(VeterinaryContext context)
        {
            _context = context;
        }
        public async Task<(Pet pet, string message, HttpStatusCode statusCode)> Add(PetDTO pet)
        {
            if (pet.Name == null || pet.Specie == null || pet.Race == null || pet.DateBirth == null || pet.Photo == null || !pet.OwnerId.HasValue)
            {
                return (null, "All fields are required.", HttpStatusCode.BadRequest);
            }            
            var newPet = new Pet
            {
                Name = pet.Name,
                Specie = pet.Specie,
                Race = pet.Race,
                DateBirth = pet.DateBirth,
                Photo = pet.Photo,
                OwnerId = pet.OwnerId.Value
            };
            await _context.Pets.AddAsync(newPet);
            await _context.SaveChangesAsync();
            return (newPet, "Pet created correctly", HttpStatusCode.Created);
        }

        public async Task<(IEnumerable<Pet> pets, string message, HttpStatusCode statusCode)> GetAll()
        {
            var pets = await _context.Pets.Include(p => p.Owner).ToListAsync();
            if (pets.Any())
                return (pets, "Pets successfully obtained", HttpStatusCode.OK);
            else
                return (null, "Pets not found!", HttpStatusCode.NotFound);
        }

        public async Task<(Pet pet, string message, HttpStatusCode statusCode)> GetById(int id)
        {
            var pet = await _context.Pets.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == id);
            if (pet != null)
                return (pet, "Pet successfully obtained", HttpStatusCode.OK);
            else
                return (null, $"Pet not found with ID {id}!", HttpStatusCode.NotFound);
        }

        public async Task<(Pet pet, string message, HttpStatusCode statusCode)> Update(int id, PetDTO petUpdate)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return (null, "Pet not found!", HttpStatusCode.NotFound);
            }

            // Update required fields only if not null
            if (!string.IsNullOrEmpty(petUpdate.Name))
            {
                pet.Name = petUpdate.Name;
            }
            if (!string.IsNullOrEmpty(petUpdate.Specie))
            {
                pet.Specie = petUpdate.Specie;
            }
            if (!string.IsNullOrEmpty(petUpdate.Race))
            {
                pet.Race = petUpdate.Race;
            }
            if (petUpdate.DateBirth != null)
            {
                pet.DateBirth = petUpdate.DateBirth;
            }
            if (!string.IsNullOrEmpty(petUpdate.Photo))
            {
                pet.Photo = petUpdate.Photo;
            }
            if (petUpdate.OwnerId.HasValue && petUpdate.OwnerId != 0)
            {
                pet.OwnerId = petUpdate.OwnerId.Value;
            }

            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (pet, "Pet updated correctly", HttpStatusCode.OK);
        }
    }
}