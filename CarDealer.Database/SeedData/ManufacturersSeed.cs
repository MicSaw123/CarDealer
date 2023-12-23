using CarDealer.Domain.Entities;

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
            }
            };
        }
    }
}
