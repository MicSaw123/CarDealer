using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class CarColorsSeed
    {
        public List<CarColor> GetCarColors()
        {
            return new List<CarColor>()
            {
                new CarColor
                {
                    Id = 1,
                    Name = "Red"
                },
                new CarColor
                {
                    Id = 2,
                    Name = "Blue"
                },
                new CarColor
                {
                    Id = 3,
                    Name = "Green"
                },
                new CarColor
                {
                    Id = 4,
                    Name = "Yellow"
                },
                new CarColor
                {
                    Id = 5,
                    Name = "Black"
                },
                new CarColor
                {
                    Id = 6,
                    Name = "White"
                },
                new CarColor
                {
                    Id = 7,
                    Name = "Gray"
                },
                new CarColor
                {
                    Id = 8,
                    Name = "Silver"
                },
                new CarColor
                {
                    Id = 9,
                    Name = "Brown"
                },
                new CarColor
                {
                    Id = 10,
                    Name = "Orange"
                }
            };
        }
    }
}
