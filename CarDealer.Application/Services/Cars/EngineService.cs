using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class EngineService : IEngineService
    {
        private readonly IEngineRepository _engineRepository;
        private readonly IMapper _mapper;

        public EngineService(IEngineRepository engineRepository, IMapper mapper)
        {
            _engineRepository = engineRepository;
            _mapper = mapper;
        }
        public async Task<RequestResult<IEnumerable<EngineDto>>> GetEngines()
        {
            var engines = await _engineRepository.GetAllAsync();
            IEnumerable<EngineDto> engineDtos = _mapper.Map<IEnumerable<EngineDto>>(engines);
            if (engines is null)
            {
                return RequestResult<IEnumerable<EngineDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<EngineDto>>.Success(engineDtos);
        }

        public async Task<RequestResult<Engine>> GetEngineById(int engineId)
        {
            var engine = await _engineRepository.GetByIdAsync(engineId);
            if (engine is null)
            {
                return RequestResult<Engine>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<Engine>.Success(engine);
        }
    }
}
