using Microsoft.EntityFrameworkCore;

namespace AnimalShelterAPI.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
          
        }

        public DbSet<Animal> Animals { get; set; }
    
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Animal>()
          .HasData(
            new Animal {AnimalId = 1, Name= "A dog", Breed= "something", Age= 2, Gender= "male" },
            new Animal {AnimalId = 2, Name= "Spot", Breed= "something", Age= 40, Gender= "Male"},
            new Animal {AnimalId = 3, Name= "Phil", Breed= "something", Age= 45, Gender= "female"},
            new Animal {AnimalId = 4, Name= "bob", Breed="something", Age= 34, Gender= "male"},
            new Animal {AnimalId = 5, Name= "dontknow", Breed= "something", Age= 2, Gender= "female"},
            new Animal {AnimalId = 6, Name= "nope", Breed= "something", Age= 200, Gender= "???"}
          );
        }
    }
}