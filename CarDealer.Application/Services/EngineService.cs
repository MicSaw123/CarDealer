using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Services
{
    public class EngineService : IEngineService
    {
        private readonly IEngineRepository _engineRepository;

        public EngineService(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }
        public async Task<IEnumerable<Engine>> GetEngines()
        {
            return await _engineRepository.GetAllAsync();
        }

        public async Task<Engine> GetEngineById(int engineId)
        {
            var engine = await _engineRepository.GetByIdAsync(engineId);
            return engine;
        }
    }
}
