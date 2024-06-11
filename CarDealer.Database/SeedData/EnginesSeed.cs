using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class EnginesSeed
    {
        public List<Engine> GetEngines()
        {
            return new List<Engine>
            {
                new Engine
                {
                    Id = 1,
                    Name = "M113",
                    Cylinders = 8,
                    Horsepower = 306,
                    Torque = 460,
                    Displacement = 4999,
                    FuelTypeId = 1
                },
                new Engine
                {
                    Id = 2,
                    Name = "M273",
                    Cylinders = 8,
                    Horsepower = 388,
                    Torque = 530,
                    Displacement = 5461,
                    FuelTypeId = 1
                }
            };
        }
    }
}
