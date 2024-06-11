using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Address;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Address;

namespace CarDealer.Application.Repositories.Address
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(IDbContext context) : base(context)
        {
        }
    }
}
