using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class EngineRepository : IEngineRepository
    {
        private readonly IDbContext _context;

        private readonly DbSet<Engine> _entities;
        public EngineRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<Engine>();
        }
        public void Add(Engine entity)
        {
            _entities.Add(entity);
        }

        public async Task<Engine> FindByConditionAsync(Expression<Func<Engine, bool>> predicate)
        {
            return await _context.Set<Engine>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Engine>> GetAllAsync(IEnumerable<Expression<Func<Engine, object>>> includes = default)
        {
            IQueryable<Engine> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }

            return await queryable.ToListAsync();
        }
        public async Task<Engine> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
