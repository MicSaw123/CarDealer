using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Address;
using CarDealer.Application.Interfaces.Repositories.Address;
using CarDealer.Application.Interfaces.Services.Address;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Address
{
    public class AddressService : IAddressService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public AddressService(ICountryRepository countryRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _countryRepository = countryRepository;
        }
        public async Task<RequestResult<IEnumerable<CountryDto>>> GetCountries()
        {
            var countries = await _countryRepository.GetAllAsync();
            IEnumerable<CountryDto> countryDtos = _mapper.Map<IEnumerable<CountryDto>>(countries);
            if (countries is null)
            {
                return RequestResult<IEnumerable<CountryDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<CountryDto>>.Success(countryDtos);
        }

        public async Task<RequestResult<IEnumerable<CityDto>>> GetCityByCountryId(int countryId, CancellationToken cancellationToken = default)
        {
            var cities = await _cityRepository.GetCitiesByCountryIdAsync(countryId, cancellationToken);
            IEnumerable<CityDto> cityDtos = _mapper.Map<IEnumerable<CityDto>>(cities);
            if (cityDtos is null)
            {
                return RequestResult<IEnumerable<CityDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<CityDto>>.Success(cityDtos);
        }


    }
}
