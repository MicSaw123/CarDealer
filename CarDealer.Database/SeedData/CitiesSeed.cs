using CarDealer.Domain.Entities.Address;

namespace CarDealer.Database.SeedData
{
    internal class CitiesSeed
    {
        public List<City> GetCities()
        {
            return new List<City>()
            {
                new City
                {
                    Id = 1,
                    CountryId = 1,
                    Name = "Koronowo",
                    ZipCode = "86-010"
                },
                new City
                {
                    Id = 2,
                    CountryId = 1,
                    Name = "Bydgoszcz",
                    ZipCode = "85-008"
                }
            };
        }
    }
}
