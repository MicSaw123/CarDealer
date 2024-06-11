using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class CarConditionsSeed
    {
        public List<CarCondition> GetCarConditions()
        {
            return new List<CarCondition>
            {
                new CarCondition
                {
                    Id = 1,
                    Name = "New",
                },
                new CarCondition
                {
                    Id = 2,
                    Name = "Used"
                },
                new CarCondition
                {
                    Id = 3,
                    Name = "Damaged"
                }
            };
        }
    }
}
