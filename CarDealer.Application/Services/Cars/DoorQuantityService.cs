using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class DoorQuantityService : IDoorQuantityService
    {
        private readonly IDoorQuantityRepository _doorQuantityRepository;
        private readonly IMapper _mapper;

        public DoorQuantityService(IDoorQuantityRepository doorQuantityRepository, IMapper mapper)
        {
            _doorQuantityRepository = doorQuantityRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<DoorQuantityDto>>> GetDoorQuantities()
        {
            var doorQuantities = await _doorQuantityRepository.GetAllAsync();
            IEnumerable<DoorQuantityDto> doorQuantityDtos = _mapper.Map<IEnumerable<DoorQuantityDto>>(doorQuantities);
            if (doorQuantityDtos is null)
            {
                return RequestResult<IEnumerable<DoorQuantityDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<DoorQuantityDto>>.Success(doorQuantityDtos);
        }
    }
}
