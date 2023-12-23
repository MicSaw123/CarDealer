using CarDealer.Domain.Entities;

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
                }
            };
        }
    }
}
