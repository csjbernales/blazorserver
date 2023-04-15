using Microsoft.EntityFrameworkCore;

namespace blazorserver.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "League of Legends",
                    Developer = "Riot Games",
                    ReleaseDate = new DateOnly(2000, 1, 1)
                },
                new Game
                {
                    Id = 2,
                    Name = "Oxygen Not Included",
                    Developer = "Klei",
                    ReleaseDate = new DateOnly(2010, 12, 12)
                });

        }
        public static DbSet<Game> Games() => Set<Game>();
    }
}
