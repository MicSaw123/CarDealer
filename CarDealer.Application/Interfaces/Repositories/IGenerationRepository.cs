using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Repositories
{
    public interface IGenerationRepository : IGenericRepository<Generation>
    {
        public Task<IEnumerable<Generation>> GetGenerationByModelIdAsync(int modelId, CancellationToken cancellationToken = default);
    }
}
