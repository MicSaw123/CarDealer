using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Services
{
    public interface IGenerationService
    {
        public Task<Generation> GetGenerationById(int generationId);

        public Task<IEnumerable<Generation>> GetGenerations();

        public Task<IEnumerable<Generation>> GetGenerationsByModelIdAsync(int modelId, CancellationToken cancellationToken = default);

    }
}
