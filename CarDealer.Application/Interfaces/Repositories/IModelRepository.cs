using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Repositories
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        public Task<IEnumerable<Model>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken);
    }
}
