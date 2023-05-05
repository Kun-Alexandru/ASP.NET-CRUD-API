using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=animalshelterdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
    }
}
