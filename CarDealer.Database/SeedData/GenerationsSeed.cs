using CarDealer.Domain.Entities;

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
                   Name = "C215",
                   ModelId = 1
               },
               new Generation
               {
                   Id = 2,
                   Name = "C216",
                   ModelId = 1
               }
            };
        }
    }
}
