using System.Net;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Models;

namespace pruebaDesempeno.Services.Owners
{
    public interface IOwnersRepository
    {
        Task<(Owner owner, string message, HttpStatusCode statusCode)> Add(OwnerDTO owner);  
        Task<(IEnumerable<Owner> owners, string message, HttpStatusCode statusCode)> GetAll();
        Task<(Owner owner, string message, HttpStatusCode statusCode)> GetById(int id);
        Task<(Owner owner, string message, HttpStatusCode statusCode)> Update(int id, OwnerDTO ownerUpdate);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}