using AnimalShelter.Data;
using AnimalShelter.Model;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Repository
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly DataContext _context;
        public AnimalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAnimal(Animal animal)
        {
            if(animal == null) 
            {
                throw new ArgumentNullException("Invalid animal");
            }
            var shelters = _context.Set<Shelter>().ToList();
            int shId = animal.ShelterId;
            bool isShelterIdInList = false;
            for (int i = 0; i < shelters.Count; i++)
            {
                if (shelters[i].Id == shId)
                {
                    isShelterIdInList = true;
                    break;
                }
            }
            if(isShelterIdInList == false)
            {
                throw new ArgumentNullException();
            }
            _context.Set<Animal>().Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnimal(int animalId)
        {
            var animal = await GetAnimalById(animalId);
            if (animal == null)
            {
                throw new ArgumentNullException("Invalid animal");
            }
            _context.Remove(animal);
            await _context.SaveChangesAsync();
        }

        public async Task<Animal> GetAnimalById(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
            if(animal == null) { throw new ArgumentNullException(); }
            return animal;
        }

        public Task<List<Animal>> GetAllAnimals()
        {
            var animals = _context.Set<Animal>().ToList() as List<Animal>;
            return Task.FromResult(animals);
        }

        public async Task<Animal> UpdateAnimal(Animal animal)
        {
            if (animal == null) { throw new ArgumentNullException(); }
            var foundAnimal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == animal.Id);
            if (foundAnimal == null) { throw new ArgumentNullException(); }
            _context.Entry(foundAnimal).CurrentValues.SetValues(animal);
            await _context.SaveChangesAsync();
            return animal;
        }
    }
}
