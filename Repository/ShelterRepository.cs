using AnimalShelter.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Repository
{
    public class ShelterRepository : IShelterRepository
    {

        private readonly DataContext _context;
        public ShelterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddShelter(Shelter shelter)
        {
            if (shelter == null)
            {
                throw new ArgumentNullException("Invalid shelter");
            }
            _context.Set<Shelter>().Add(shelter); ;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShelter(int shelterId)
        {
            var shelter = await GetShelterById(shelterId);
            if (shelter == null)
            {
                throw new ArgumentNullException("Invalid shelter");
            }
            _context.Remove(shelter);
            await _context.SaveChangesAsync();
        }

        public async Task<Shelter> GetShelterById(int id)
        {
            var shelter = await _context.Shelters.FirstOrDefaultAsync(a => a.Id == id);
            if (shelter == null) { throw new ArgumentNullException(); }
            return shelter;
        }

        public Task<List<Shelter>> GetAllShelters()
        {
            var shelters = _context.Set<Shelter>().ToList() as List<Shelter>;
            return Task.FromResult(shelters);
        }

        public async Task<Shelter> UpdateShelter(Shelter shelter)
        {
            if (shelter == null) { throw new ArgumentNullException(); }
            var foundShelter = await _context.Shelters.FirstOrDefaultAsync(a => a.Id == shelter.Id);
            if (foundShelter == null) { throw new ArgumentNullException(); }
            _context.Entry(foundShelter).CurrentValues.SetValues(shelter);
            await _context.SaveChangesAsync();
            return shelter;
        }
    }
}

