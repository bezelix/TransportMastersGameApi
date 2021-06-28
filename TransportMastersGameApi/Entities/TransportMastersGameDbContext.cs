using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class TransportMastersGameDbContext : DbContext 
    {
        private string _connectionString =
        "Server=(localdb)\\mssqllocaldb; Database=TransportMastersGame;Trusted_Connection=True;";
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoType> CargoTypes { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<ModelName> ModelNames { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(c => c.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
               .Property(c => c.FirstName)
               .IsRequired();
            modelBuilder.Entity<User>()
               .Property(c => c.LastName)
               .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
