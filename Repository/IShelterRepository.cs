namespace AnimalShelter.Repository
{
    public interface IShelterRepository
    {
        public Task AddShelter(Shelter shelter);

        public Task DeleteShelter(int shelterId);

        public Task<Shelter> UpdateShelter(Shelter shelter);

        public Task<List<Shelter>> GetAllShelters();

        public Task<Shelter> GetShelterById(int id);


    }
}
