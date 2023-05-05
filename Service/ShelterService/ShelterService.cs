using AnimalShelter.Repository;
using AnimalShelter.Service.AnimalService;

namespace AnimalShelter.Service.ShelterService
{
    public class ShelterService : IShelterService
    {

        private IShelterRepository _shelterRepository;

        public ShelterService(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }
        public async Task AddShelter(Shelter shelter)
        {
            await _shelterRepository.AddShelter(shelter);
        }

        public async Task DeleteShelter(int id)
        {
            await _shelterRepository.DeleteShelter(id);
        }

        public Task<List<Shelter>> GetAllShelters()
        {
            return _shelterRepository.GetAllShelters();
        }

        public async Task<Shelter> GetShelterById(int id)
        {
            return await _shelterRepository.GetShelterById(id);
        }

        public async Task<Shelter> UpdateShelter(Shelter shelter)
        {
            return await _shelterRepository.UpdateShelter(shelter);
        }

    }
}
