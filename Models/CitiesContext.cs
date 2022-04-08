using Microsoft.EntityFrameworkCore;

namespace CitiesAPI.Models
{
    public class CitiesContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Coords> Coords { get; set; }
        public CitiesContext(DbContextOptions<CitiesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<City>()
                .HasOne(u => u.Coords)
                .WithOne(p => p.City)
                .HasForeignKey<Coords>(p => p.CityKey);
        }
    }
}
