using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Services
{
    public class GenerationService : IGenerationService
    {
        private readonly IGenerationRepository _generationRepository;

        public GenerationService(IGenerationRepository generationRepository)
        {
            _generationRepository = generationRepository;
        }
        public async Task<Generation> GetGenerationById(int generationId)
        {
            var generation = await _generationRepository.GetByIdAsync(generationId);
            return generation;
        }

        public async Task<IEnumerable<Generation>> GetGenerations()
        {
            return await _generationRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Generation>> GetGenerationsByModelIdAsync(int modelId, CancellationToken cancellationToken = default)
        {
            return await _generationRepository.GetGenerationByModelIdAsync(modelId, cancellationToken);
        }
    }
}
