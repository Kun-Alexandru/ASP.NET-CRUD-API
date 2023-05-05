using AnimalShelter.Data;
using AnimalShelter.Repository;
using Microsoft.Identity.Client;
using System.Formats.Asn1;

namespace AnimalShelter.Service.AnimalService
{
    public class AnimalService : IAnimalService
    {

        private IAnimalRepository _animalRepository;
        private IShelterRepository _shelterRepository;

        public AnimalService(IAnimalRepository animalRepository, IShelterRepository shelterRepository)
        {
            _animalRepository = animalRepository;
            _shelterRepository = shelterRepository;

        }
        public async Task AddAnimal(Animal animal)
        {
            await _animalRepository.AddAnimal(animal);
            
        }

        public async Task DeleteAnimal(int id) 
            {
                await _animalRepository.DeleteAnimal(id);
            }

        public Task<List<Animal>> GetAllAnimals()
        {
                return _animalRepository.GetAllAnimals();
        }

        public async Task<Animal> GetAnimalById(int id)
        {
                return await _animalRepository.GetAnimalById(id);
        }

        public async Task<Animal> UpdateAnimal(Animal animal)
        {
            return await _animalRepository.UpdateAnimal(animal);
        }

     }
}
