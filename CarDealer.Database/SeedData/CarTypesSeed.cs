using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class CarTypesSeed
    {

        public List<CarType> GetCarTypes()
        {
            return new List<CarType>
            {
                new CarType
                {
                    Id = 1,
                    Name = "Coupe"
                },
                new CarType
                {
                    Id = 2,
                    Name = "Sedan"
                },
                new CarType
                {
                    Id = 3,
                    Name = "Station Wagon"
                },
                new CarType
                {
                    Id = 4,
                    Name = "Hatchback"
                },
                new CarType
                {
                    Id= 5,
                    Name = "Crossover"
                },
                new CarType
                {
                    Id = 6,
                    Name = "SUV"
                },
                new CarType
                {
                    Id= 7,
                    Name = "Minivan"
                },
                new CarType
                {
                    Id = 8,
                    Name = "Pickup Truck"
                },
                new CarType
                {
                    Id= 9,
                    Name = "Convertible"
                }
            };
        }
    }
}
