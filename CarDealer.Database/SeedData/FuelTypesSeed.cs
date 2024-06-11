using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class FuelTypesSeed
    {
        public List<FuelType> GetFuelTypes()
        {
            return new List<FuelType>
            {
                new FuelType
                {
                    Id = 1,
                    Name = "Petrol"
                },
                new FuelType {
                    Id = 2,
                    Name = "Diesel"
                },
                new FuelType
                {
                    Id = 3,
                    Name = "LPG"
                },
                new FuelType
                {
                    Id = 4,
                    Name = "Hybrid"
                },
                new FuelType
                {
                    Id = 5,
                    Name = "Electric"
                },
                new FuelType
                {
                    Id = 6,
                    Name = "Hydrogen"
                }
            };
        }
    }
}
