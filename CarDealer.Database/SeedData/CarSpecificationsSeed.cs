using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class CarSpecificationsSeed
    {
        public List<CarSpecification> GetCarSpecifications()
        {
            return new List<CarSpecification> {
                new CarSpecification
                {
                    Id = 1,
                    EngineId = 1,
                    TransmissionId = 1,
                    DrivetrainId = 1
                },
                new CarSpecification
                {
                    Id = 2,
                    EngineId = 2,
                    TransmissionId = 1,
                    DrivetrainId = 1
                }
            };
        }
    }
}