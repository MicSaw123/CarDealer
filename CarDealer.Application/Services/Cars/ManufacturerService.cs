using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerService(IManufacturerRepository manufacturerRepository,
            IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<ManufacturerDto>>> GetManufacturerDtos()
        {
            var manufacturers = await _manufacturerRepository.GetAllAsync();
            IEnumerable<ManufacturerDto> manufacturerDtos = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);
            if (manufacturerDtos is null)
            {
                return RequestResult<IEnumerable<ManufacturerDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<ManufacturerDto>>.Success(manufacturerDtos);
        }
    }
}
