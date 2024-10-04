using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class CarTypeService : ICarTypeService
    {
        private readonly ICarTypeRepository _carTypeRepository;
        private readonly IMapper _mapper;

        public CarTypeService(ICarTypeRepository carTypeRepository, IMapper mapper)
        {
            _carTypeRepository = carTypeRepository;
            _mapper = mapper;
        }
        public async Task<RequestResult<IEnumerable<CarTypeDto>>> GetCarTypes()
        {
            var carTypes = await _carTypeRepository.GetAllAsync();
            IEnumerable<CarTypeDto> carTypeDtos = _mapper.Map<IEnumerable<CarTypeDto>>(carTypes);
            if (carTypeDtos is null)
            {
                return RequestResult<IEnumerable<CarTypeDto>>.Failure(Error.ErrorUnknown);
            }

            return RequestResult<IEnumerable<CarTypeDto>>.Success(carTypeDtos.OrderBy(x => x.Name));

        }
    }
}
