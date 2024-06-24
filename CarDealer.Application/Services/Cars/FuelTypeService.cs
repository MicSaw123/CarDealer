using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly IMapper _mapper;

        public FuelTypeService(IFuelTypeRepository fuelTypeRepository, IMapper mapper)
        {
            _fuelTypeRepository = fuelTypeRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<FuelTypeDto>>> GetFuelTypeDtos()
        {
            var fuelTypes = await _fuelTypeRepository.GetAllAsync();
            IEnumerable<FuelTypeDto> fuelTypeDtos = _mapper.Map<IEnumerable<FuelTypeDto>>(fuelTypes);
            if (fuelTypeDtos is null)
            {
                return RequestResult<IEnumerable<FuelTypeDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<FuelTypeDto>>.Success(fuelTypeDtos);
        }
    }
}
