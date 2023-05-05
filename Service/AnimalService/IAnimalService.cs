using AnimalShelter.Model;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Service.AnimalService
{
    public interface IAnimalService
    {
        public Task<List<Animal>> GetAllAnimals();
        public Task<Animal> GetAnimalById(int id);


        public Task AddAnimal(Animal givenAnimal);

        Task<Animal> UpdateAnimal(Animal givenAnimal);

        public Task DeleteAnimal(int id);
    }
}
