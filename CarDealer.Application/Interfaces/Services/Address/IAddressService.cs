using CarDealer.Domain.Entities.Address;

namespace CarDealer.Application.Interfaces.Services.Address
{
    public interface IAddressService
    {
        public Task<RequestResult<IEnumerable<Country>>> GetCountries();

        public Task<RequestResult<IEnumerable<City>>> GetCityByCountryId(int countryId, CancellationToken cancellationToken = default);

        public Task<RequestResult<IEnumerable<City>>> GetZipCodeByCityId(int cityId, CancellationToken cancellationToken = default);
    }
}
