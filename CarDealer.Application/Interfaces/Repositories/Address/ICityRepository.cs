using CarDealer.Application.Interfaces.Repositories.Generic;
using CarDealer.Domain.Entities.Address;

namespace CarDealer.Application.Interfaces.Repositories.Address
{
    public interface ICityRepository : IGenericRepository<City>
    {
        public Task<IEnumerable<City>> GetCitiesByCountryIdAsync(int countryId, CancellationToken cancellationToken);

        public Task<IEnumerable<City>> GetZipCodesByCityIdAsync(int cityId, CancellationToken cancellationToken);
    }
}
