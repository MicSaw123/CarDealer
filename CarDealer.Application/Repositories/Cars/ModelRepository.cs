using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Application.Repositories.Cars
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Model>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken = default)
        {
            return await _entities.Where(model => model.ManufacturerId == manufacturerId).ToListAsync(cancellationToken);
        }
    }
}
