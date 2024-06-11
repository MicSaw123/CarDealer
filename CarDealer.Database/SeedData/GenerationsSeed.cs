using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class GenerationsSeed
    {
        public List<Generation> GetGenerations()
        {
            return new List<Generation>
            {
                new Generation
                {
                    Id = 1,
                    ModelId = 1,
                    Name = "C215"
                },
                new Generation
                {
                    Id = 2,
                    ModelId = 1,
                    Name = "C216"
                },
                new Generation
                {
                    Id = 3,
                    ModelId = 1,
                    Name = "C140"
                },
                new Generation
                {
                    Id = 4,
                    ModelId = 2,
                    Name = "W220"
                },
                new Generation
                {
                    Id = 5,
                    ModelId = 2,
                    Name = "W221"
                }
            };
        }
    }
}
