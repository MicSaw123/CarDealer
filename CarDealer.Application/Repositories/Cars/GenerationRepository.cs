using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Application.Repositories.Cars
{
    public class GenerationRepository : GenericRepository<Generation>, IGenerationRepository
    {
        public GenerationRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Generation>> GetGenerationByModelIdAsync(int modelId, CancellationToken cancellationToken)
        {
            return await _entities.Where(generation => generation.ModelId == modelId).ToListAsync();
        }
    }
}
