namespace AnimalShelter.Repository
{
    public interface IAnimalRepository
    {
        public Task AddAnimal(Animal animal);

        public Task DeleteAnimal(int animalId);

        public Task<Animal> UpdateAnimal(Animal animal);

        public Task<List<Animal>> GetAllAnimals();

        public Task<Animal> GetAnimalById(int id);


    }
}
