using CarDealer.Application.Interfaces.Database;
using CarDealer.Database.SeedData;
using CarDealer.Domain.Entities.Address;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Entities.Identity;
using CarDealer.Domain.Entities.Lisitngs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Database.Context
{
    public class CarDealerContext : IdentityDbContext<CarDealerUser, CarDealerRole, int>, IDbContext
    {

        public CarDealerContext(DbContextOptions<CarDealerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var carTypesSeed = new CarTypesSeed();
            var manufacturersSeed = new ManufacturersSeed();
            var modelsSeed = new ModelsSeed();
            var generationsSeed = new GenerationsSeed();
            var transmissionsSeed = new TransmissionsSeed();
            var fuelTypesSeed = new FuelTypesSeed();
            var carColorsSeed = new CarColorsSeed();
            var carConditionsSeed = new CarConditionsSeed();
            var countriesSeed = new CountriesSeed();
            var previouslyDamagedSeed = new PreviouslyDamagedSeed();
            var drivetrainsSeed = new DrivetrainsSeed();
            var doorQuantitiesSeed = new DoorQuantitiesSeed();
            var enginesSeed = new EnginesSeed();
            var citiesSeed = new CitiesSeed();
            var accountTypesSeed = new AccountTypesSeed();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Manufacturer>().HasData(manufacturersSeed.GetManufacturers());
            modelBuilder.Entity<Model>().HasData(modelsSeed.GetModels());
            modelBuilder.Entity<Generation>().HasData(generationsSeed.GetGenerations());
            modelBuilder.Entity<FuelType>().HasData(fuelTypesSeed.GetFuelTypes());
            modelBuilder.Entity<Transmission>().HasData(transmissionsSeed.GetTransmissions());
            modelBuilder.Entity<CarType>().HasData(carTypesSeed.GetCarTypes());
            modelBuilder.Entity<CarColor>().HasData(carColorsSeed.GetCarColors());
            modelBuilder.Entity<CarCondition>().HasData(carConditionsSeed.GetCarConditions());
            modelBuilder.Entity<Country>().HasData(countriesSeed.GetCountries());
            modelBuilder.Entity<PreviouslyDamaged>().HasData(previouslyDamagedSeed.GetPreviouslyDamaged());
            modelBuilder.Entity<Drivetrain>().HasData(drivetrainsSeed.GetDrivetrains());
            modelBuilder.Entity<Engine>().HasData(enginesSeed.GetEngines());
            modelBuilder.Entity<DoorQuantity>().HasData(doorQuantitiesSeed.GetDoorQuantities());
            modelBuilder.Entity<City>().HasData(citiesSeed.GetCities());
            modelBuilder.Entity<AccountType>().HasData(accountTypesSeed.GetAccountTypes());
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<CarCondition> CarConditions { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<DoorQuantity> DoorQuantity { get; set; }
        public DbSet<Drivetrain> Drivetrains { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Generation> Generations { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<PreviouslyDamaged> PreviouslyDamaged { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<IdentifiedVehicles> IdentifiedVehicles { get; set; }
        public DbSet<ListedCar> ListedCars { get; set; }
        public DbSet<ListedCarSpecification> ListedCarSpecification { get; set; }
        public DbSet<Listing> Listings { get; set; }
    }
}
