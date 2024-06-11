using CarDealer.Domain.Entities.Address;

namespace CarDealer.Database.SeedData
{
    internal class CountriesSeed
    {
        public List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country
                {
                    Id = 1,
                    Name = "Poland"
                },
                new Country
                {
                    Id = 2,
                    Name = "Germany"
                },
                new Country
                {
                    Id = 3,
                    Name = "France"
                },
                new Country
                {
                    Id = 4,
                    Name = "Spain"
                },
                new Country
                {
                    Id = 5,
                    Name = "Italy"
                },
                new Country
                {
                    Id = 6,
                    Name = "Portugal"
                },
                new Country
                {
                    Id = 7,
                    Name = "Netherlands"
                },
                new Country
                {
                    Id = 8,
                    Name = "Belgium"
                },
                new Country
                {
                    Id = 9,
                    Name = "Sweden"
                },
                new Country
                {
                    Id = 10,
                    Name = "Norway"
                }
            };
        }
    }
}
