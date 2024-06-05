using System.Net;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Models;

namespace pruebaDesempeno.Services.Vets
{
    public interface IVetsRepository
    {
        // ********All lines of code that are commented out are not required by the system but may be implemented in the future.********
        
        //Task<(Vet vet, string message, HttpStatusCode statusCode)> Add(VetDTO vet);  
        Task<(IEnumerable<Vet> vets, string message, HttpStatusCode statusCode)> GetAll();
        Task<(Vet vet, string message, HttpStatusCode statusCode)> GetById(int id);
        //Task<(Vet vet, string message, HttpStatusCode statusCode)> Update(int id, VetDTO vetUpdate);
        //Task<bool> IsEmailUniqueAsync(string email);
    }
}