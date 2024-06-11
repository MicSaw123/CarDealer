using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class ManufacturersSeed
    {
        public List<Manufacturer> GetManufacturers()
        {
            return new List<Manufacturer>
            {
            new Manufacturer
            {
                Id = 1,
                Name = "Mercedes-Benz"
            },
            new Manufacturer
            {
                Id = 2,
                Name = "BMW"
            },
            new Manufacturer
            {
                Id = 3,
                Name = "Audi"
            },
            new Manufacturer
            {
                Id = 4,
                Name = "Volkswagen"
            },
            new Manufacturer
            {
                Id = 5,
                Name = "Porsche"
            },
            new Manufacturer
            {
                Id = 6,
                Name = "Toyota"
            },
            new Manufacturer
            {
                Id = 7,
                Name = "Honda"
            },
            new Manufacturer
            {
                Id = 8,
                Name = "Nissan"
            },
            new Manufacturer
            {
                Id = 9,
                Name = "Ford"
            },
            new Manufacturer
            {
                Id = 10,
                Name = "Chevrolet"
            }
            };
        }
    }
}
