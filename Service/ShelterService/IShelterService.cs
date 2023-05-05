namespace AnimalShelter.Service.ShelterService
{
    public interface IShelterService
    {
        public Task<List<Shelter>> GetAllShelters();
        public Task<Shelter> GetShelterById(int id);

        public Task AddShelter(Shelter givenShelter);

        Task<Shelter> UpdateShelter(Shelter givenShelter);

        public Task DeleteShelter(int id);
    }
}
