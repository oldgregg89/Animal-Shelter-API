using Microsoft.EntityFrameworkCore;

namespace AnimalShelterAPI.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }

        public DbSet<Cats> Cats { get; set; }
    }
}