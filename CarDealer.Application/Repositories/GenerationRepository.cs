using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class GenerationRepository : IGenerationRepository
    {
        private readonly IDbContext _context;

        private readonly DbSet<Generation> _entities;

        public GenerationRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<Generation>();
        }

        public void Add(Generation entity)
        {
            _entities.Add(entity);
        }

        public async Task<Generation> FindByConditionAsync(Expression<Func<Generation, bool>> predicate)
        {
            return await _context.Set<Generation>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Generation>> GetAllAsync(IEnumerable<Expression<Func<Generation, object>>> includes = null)
        {
            IQueryable<Generation> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }
            return await queryable.ToListAsync();
        }

        public async Task<Generation> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Generation>> GetGenerationByModelIdAsync(int modelId, CancellationToken cancellationToken)
        {
            return await _entities.Where(generation => generation.ModelId == modelId).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }


    }
}
