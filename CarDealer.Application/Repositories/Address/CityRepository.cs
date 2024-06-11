using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Address;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Application.Repositories.Address
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<City>> GetCitiesByCountryIdAsync(int countryId, CancellationToken cancellationToken)
        {
            return await _entities.Where(c => c.CountryId == countryId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<City>> GetZipCodesByCityIdAsync(int cityId, CancellationToken cancellationToken)
        {
            return await _entities.Where(c => c.Id == cityId).ToListAsync(cancellationToken);
        }
    }
}
