using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class DoorQuantitiesSeed
    {
        public List<DoorQuantity> GetDoorQuantities()
        {
            return new List<DoorQuantity>
            {
                new DoorQuantity
                {
                    Id = 1,
                    Doors = 2
                },
                new DoorQuantity
                {
                    Id = 2,
                    Doors = 4
                },
                new DoorQuantity
                {
                    Id = 3,
                    Doors = 6
                },
            };
        }
    }
}
