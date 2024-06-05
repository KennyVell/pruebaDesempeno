using Microsoft.EntityFrameworkCore;
using pruebaDesempeno.Data;
using pruebaDesempeno.Models;
using pruebaDesempeno.DTOs;
using System.Net;

namespace pruebaDesempeno.Services.Owners
{
    public class OwnersRepository : IOwnersRepository
    {
        private readonly VeterinaryContext _context;
        public OwnersRepository(VeterinaryContext context)
        {
            _context = context;
        }
        public async Task<(Owner owner, string message, HttpStatusCode statusCode)> Add(OwnerDTO owner)
        {
            if (owner.Names == null || owner.LastNames == null || owner.Email == null || owner.Address == null || owner.Phone == null)
            {
                return (null, "All fields are required.", HttpStatusCode.BadRequest);
            }            
            var newOwner = new Owner
            {
                Names = owner.Names,
                LastNames = owner.LastNames,
                Email = owner.Email,
                Address = owner.Address,
                Phone = owner.Phone
            };
            await _context.Owners.AddAsync(newOwner);
            await _context.SaveChangesAsync();
            return (newOwner, "Owner created correctly", HttpStatusCode.Created);
        }

        public async Task<(IEnumerable<Owner> owners, string message, HttpStatusCode statusCode)> GetAll()
        {
            var owners = await _context.Owners.ToListAsync();
            if (owners.Any())
                return (owners, "Owners successfully obtained", HttpStatusCode.OK);
            else
                return (null, "Owners not found!", HttpStatusCode.NotFound);
        }

        public async Task<(Owner owner, string message, HttpStatusCode statusCode)> GetById(int id)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(p => p.Id == id);
            if (owner != null)
                return (owner, "Owner successfully obtained", HttpStatusCode.OK);
            else
                return (null, $"Owner not found with ID {id}!", HttpStatusCode.NotFound);
        }

        public async Task<(Owner owner, string message, HttpStatusCode statusCode)> Update(int id, OwnerDTO ownerUpdate)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return (null, "Owner not found!", HttpStatusCode.NotFound);
            }

            // Update required fields only if not null
            if (!string.IsNullOrEmpty(ownerUpdate.Names))
            {
                owner.Names = ownerUpdate.Names;
            }
            if (!string.IsNullOrEmpty(ownerUpdate.LastNames))
            {
                owner.LastNames = ownerUpdate.LastNames;
            }
            if (!string.IsNullOrEmpty(ownerUpdate.Email))
            {
                owner.Email = ownerUpdate.Email;
            }
            if (!string.IsNullOrEmpty(ownerUpdate.Address))
            {
                owner.Address = ownerUpdate.Address;
            }
            if (!string.IsNullOrEmpty(ownerUpdate.Phone))
            {
                owner.Phone = ownerUpdate.Phone;
            }

            _context.Entry(owner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (owner, "Owner updated correctly", HttpStatusCode.OK);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _context.Owners.AnyAsync(u => u.Email == email);
        }
    }
}