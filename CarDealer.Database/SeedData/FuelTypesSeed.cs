using CarDealer.Domain.Entities;

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
                }
            };
        }
    }
}
