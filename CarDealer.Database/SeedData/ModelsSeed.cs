
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    public class ModelsSeed
    {
        public List<Model> GetModels()
        {
            return new List<Model>
            {
                new Model
                {
                    Id = 1,
                    ManufacturerId = 1,
                    Name = "CL"
                },
                new Model
                {
                    Id = 2,
                    ManufacturerId = 1,
                    Name = "S Class"
                },
                new Model
                {
                    Id = 3,
                    ManufacturerId = 1,
                    Name = "E Class"
                },
                new Model
                {
                    Id = 4,
                    ManufacturerId = 1,
                    Name = "C Class"
                },
                new Model
                {
                    Id = 5,
                    ManufacturerId = 1,
                    Name = "G Class"
                },
                new Model {
                    Id = 6,
                    ManufacturerId = 1,
                    Name = "GLA Class"
               },
                new Model
                {
                    Id= 7,
                    ManufacturerId = 1,
                    Name = "GLC Class"
                },
                new Model
                {
                    Id = 8,
                    ManufacturerId = 1,
                    Name = "GLE Class"
                },
                new Model
                {
                    Id = 9,
                    ManufacturerId = 1,
                    Name = "A Class"
                },
                new Model
                {
                    Id = 10,
                    ManufacturerId = 1,
                    Name = "B Class"
                }
            };
        }
    }
}
