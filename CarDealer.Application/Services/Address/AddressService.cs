using CarDealer.Application.Interfaces.Repositories.Address;
using CarDealer.Application.Interfaces.Services.Address;
using CarDealer.Domain.Entities.Address;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Address
{
    public class AddressService : IAddressService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;

        public AddressService(ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }
        public async Task<RequestResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _countryRepository.GetAllAsync();
            if (countries is null)
            {
                return RequestResult<IEnumerable<Country>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<Country>>.Success(countries);
        }

        public async Task<RequestResult<IEnumerable<City>>> GetCityByCountryId(int countryId, CancellationToken cancellationToken = default)
        {
            var cities = await _cityRepository.GetCitiesByCountryIdAsync(countryId, cancellationToken);
            if (cities is null)
            {
                return RequestResult<IEnumerable<City>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<City>>.Success(cities);
        }

        public async Task<RequestResult<IEnumerable<City>>> GetZipCodeByCityId(int cityId, CancellationToken cancellationToken = default)
        {
            var zipCode = await _cityRepository.GetZipCodesByCityIdAsync(cityId, cancellationToken);
            if (zipCode is null)
            {
                return RequestResult<IEnumerable<City>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<City>>.Success(zipCode);
        }

    }
}
