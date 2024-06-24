using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class CarConditionService : ICarConditionService
    {
        private readonly ICarConditionRepository _carConditionRepository;
        private readonly IMapper _mapper;

        public CarConditionService(ICarConditionRepository carConditionRepository, IMapper mapper)
        {
            _carConditionRepository = carConditionRepository;
            _mapper = mapper;
        }
        public async Task<RequestResult<IEnumerable<CarConditionDto>>> GetCarConditions()
        {
            var carConditions = await _carConditionRepository.GetAllAsync();
            IEnumerable<CarConditionDto> carConditionDtos = _mapper.Map<IEnumerable<CarConditionDto>>(carConditions);
            if (carConditionDtos is null)
            {
                return RequestResult<IEnumerable<CarConditionDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<CarConditionDto>>.Success(carConditionDtos);
        }
    }
}
