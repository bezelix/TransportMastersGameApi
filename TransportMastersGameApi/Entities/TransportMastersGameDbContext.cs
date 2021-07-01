using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class TransportMastersGameDbContext : DbContext 
    {
        public TransportMastersGameDbContext(DbContextOptions<TransportMastersGameDbContext> options) : base(options)
        {

        }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoSize> Sizes { get; set; }
        public DbSet<CargoType> CargoTypes { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<ModelName> ModelNames { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(c => c.Email)
                .IsRequired();
        }
    }
}
