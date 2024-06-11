using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class EngineService : IEngineService
    {
        private readonly IEngineRepository _engineRepository;

        public EngineService(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }
        public async Task<RequestResult<IEnumerable<Engine>>> GetEngines()
        {
            var engines = await _engineRepository.GetAllAsync();
            if (engines is null)
            {
                return RequestResult<IEnumerable<Engine>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<Engine>>.Success(engines);
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
