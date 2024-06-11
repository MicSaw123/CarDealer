using CarDealer.Application.Interfaces.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Repositories.Cars
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        public Task<IEnumerable<Model>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken);
    }
}
