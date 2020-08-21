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
    
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<State>()
          .HasData(
            new State {DogId = 1, Name= "A dog", Breed= "something", Age= "2", Gender= "male" },
            new State {CatId = 1, Name= "Spot", Breed= "something", Age= "40", Grender= "Male"},
            new State {DogId = 2, Name= "Phil", Breed= "something", Age= 45, Grender= "female"},
            new State {CatId = 2, Name= "bob", Breed="something", Age= "34", Grender= "male"},
            new State {DogId = 3, Name= "dontknow", Breed= "something", Age= "2", Grender= "female"},
            new State {CatId = 3, Name= "nope", Breed= "something", Age= "200", Grender= "???"}
          );
        }
    }
}