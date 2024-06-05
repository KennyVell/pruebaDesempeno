using System.Net;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Models;

namespace pruebaDesempeno.Services.Pets
{
    public interface IPetsRepository
    {
        Task<(Pet pet, string message, HttpStatusCode statusCode)> Add(PetDTO pet);  
        Task<(IEnumerable<Pet> pets, string message, HttpStatusCode statusCode)> GetAll();
        Task<(Pet pet, string message, HttpStatusCode statusCode)> GetById(int id);
        Task<(IEnumerable<Pet> pets, string message, HttpStatusCode statusCode)> GetByOwnerId(int id);
        Task<(IEnumerable<Pet> pets, string message, HttpStatusCode statusCode)> GetByBirthDate(DateTime date);
        Task<(Pet pet, string message, HttpStatusCode statusCode)> Update(int id, PetDTO petUpdate);
    }
}