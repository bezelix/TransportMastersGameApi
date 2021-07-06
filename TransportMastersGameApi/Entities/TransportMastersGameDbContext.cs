using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class TransportMastersGameDbContext : DbContext 
    {
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
        public DbSet<Continent> Continent { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<CargoTemplate> CargoTemplate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(c => c.Email)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("Server=s119.cyber-folks.pl,3306;Database=daadipmcej_transportmastersgame;User Id=daadipmcej_bezelix;Password=2rmJ(s-f1Ip-)4S!;", new MySqlServerVersion(new Version(10, 3, 29)))
                .UseLoggerFactory(LoggerFactory.Create(b => b
                    .AddConsole()
                    .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
