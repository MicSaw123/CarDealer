using CarDealer.Application.Interfaces.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Repositories.Cars
{
    public interface IGenerationRepository : IGenericRepository<Generation>
    {
        public Task<IEnumerable<Generation>> GetGenerationByModelIdAsync(int modelId, CancellationToken cancellationToken = default);
    }
}
