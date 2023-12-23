using CarDealer.Application.Interfaces.Database;
using CarDealer.Database.SeedData;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Database.Context
{
    public class CarDealerContext : DbContext, IDbContext
    {
        public CarDealerContext(DbContextOptions<CarDealerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var carTypesSeed = new CarTypesSeed();
            var manufacturersSeed = new ManufacturersSeed();
            var modelsSeed = new ModelsSeed();
            var enginesSeed = new EnginesSeed();
            var transmissionsSeed = new TransmissionsSeed();
            var generationsSeed = new GenerationsSeed();
            var fuelTypesSeed = new FuelTypesSeed();
            var carSpecificationsSeed = new CarSpecificationsSeed();
            var CarsSeed = new CarsSeed();

            modelBuilder.Entity<CarType>().HasData(
                 carTypesSeed.GetCarTypes()
                 );
            modelBuilder.Entity<Manufacturer>().HasData(
                 manufacturersSeed.GetManufacturers()
                 );
            modelBuilder.Entity<Model>().HasData(
                modelsSeed.GetModels()
                );
            modelBuilder.Entity<Engine>().HasData(
                enginesSeed.GetEngines()
                );
            modelBuilder.Entity<Transmission>().HasData(
                transmissionsSeed.GetTransmissions()
                );
            modelBuilder.Entity<FuelType>().HasData(
               fuelTypesSeed.GetFuelTypes()
                );
            modelBuilder.Entity<CarSpecification>().HasData(
                carSpecificationsSeed.GetCarSpecifications()
                );
            modelBuilder.Entity<Generation>().HasData(
                generationsSeed.GetGenerations()
                );
            modelBuilder.Entity<Car>().HasData(
                CarsSeed.GetCars()
                );

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarSpecification> CarsSpecifications { get; set; }

        public DbSet<CarType> CarTypes { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<FuelType> FuelTypes { get; set; }

        public DbSet<Generation> Generations { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Transmission> Transmissions { get; set; }
    }
}
