using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class PreviouslyDamagedService : IPreviouslyDamagedService
    {
        private readonly IPreviouslyDamagedRepository _previouslyDamagedRepository;
        private readonly IMapper _mapper;

        public PreviouslyDamagedService(IPreviouslyDamagedRepository previouslyDamagedRepository, IMapper mapper)
        {
            _previouslyDamagedRepository = previouslyDamagedRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<PreviouslyDamagedDto>>> GetPreviouslyDamaged()
        {
            var previouslyDamaged = await _previouslyDamagedRepository.GetAllAsync();
            IEnumerable<PreviouslyDamagedDto> previouslyDamagedDtos = _mapper.
                Map<IEnumerable<PreviouslyDamagedDto>>(previouslyDamaged);
            if (previouslyDamagedDtos is null)
            {
                return RequestResult<IEnumerable<PreviouslyDamagedDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<PreviouslyDamagedDto>>.Success(previouslyDamagedDtos);
        }
    }
}
