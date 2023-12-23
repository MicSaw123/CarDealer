using CarDealer.Domain.Entities;

namespace CarDealer.Database.SeedData
{
    internal class CarsSeed
    {
        public List<Car> GetCars()
        {
            return new List<Car> {
             new Car
            {
                 Id = 1,
                 CarSpecificationId = 1,
                 CarTypeId = 1,
                 GenerationId = 1
            },
             new Car
             {
                 Id = 2,
                 CarSpecificationId = 2,
                 CarTypeId = 1,
                 GenerationId = 2
             }
            };
        }
    }
}
