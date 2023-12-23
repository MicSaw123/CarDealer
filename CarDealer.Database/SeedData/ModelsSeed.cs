using CarDealer.Domain.Entities;

namespace CarDealer.Database.SeedData
{
    internal class ModelsSeed
    {
        public List<Model> GetModels()
        {
            return new List<Model>
            {
                new Model
                {
                    Id = 1,
                    Name = "CL",
                    ManufacturerId = 1
                }
            };
        }
    }
}
