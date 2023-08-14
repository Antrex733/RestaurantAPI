using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDBContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=RRestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set;}
        public DbSet<Address> Addresses { get; set;}
        public DbSet<Dish> Dishes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(n => n.Name)
                .IsRequired();

            //błąd więc GPT
            modelBuilder.Entity<Dish>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // Przykładowa precyzja i skala

            //zadanie filmik 17
            modelBuilder.Entity<Address>()
                .Property(c => c.City)
                .HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(c => c.Street)
                .HasMaxLength(50);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
