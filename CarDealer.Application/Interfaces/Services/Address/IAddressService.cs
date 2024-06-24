using CarDealer.Application.DataTransferObjects.Dtos.Address;

namespace CarDealer.Application.Interfaces.Services.Address
{
    public interface IAddressService
    {
        public Task<RequestResult<IEnumerable<CountryDto>>> GetCountries();

        public Task<RequestResult<IEnumerable<CityDto>>> GetCityByCountryId(int countryId, CancellationToken cancellationToken = default);

    }
}
