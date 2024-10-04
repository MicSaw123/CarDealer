using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class CarColorService : ICarColorService
    {
        private readonly ICarColorRepository _carColorRepository;
        private readonly IMapper _mapper;

        public CarColorService(ICarColorRepository carColorRepository, IMapper mapper)
        {
            _carColorRepository = carColorRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<CarColorDto>>> GetCarColors()
        {
            var carColors = await _carColorRepository.GetAllAsync();
            IEnumerable<CarColorDto> carColorDtos = _mapper.Map<IEnumerable<CarColorDto>>(carColors);
            if (carColorDtos is null)
            {
                return RequestResult<IEnumerable<CarColorDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<CarColorDto>>.Success(carColorDtos.OrderBy(x => x.Name));
        }
    }
}
