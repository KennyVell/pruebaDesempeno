using pruebaDesempeno.DTOs;
using pruebaDesempeno.Models;

namespace pruebaDesempeno.Services.Pets
{
    public interface IPetsRepository
    {
        Task<(Pet pet, string message)> Add(PetDTO pet);  
        Task<(IEnumerable<Pet> pets, string message)> GetAll();
        Task<(Pet pet, string message)> GetById(int id);
        Task<(Pet pet, string message)> Update(int id, PetDTO petUpdate);
    }
}