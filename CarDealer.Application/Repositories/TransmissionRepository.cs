using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class TransmissionRepository : ITransmissionRepository
    {
        private readonly IDbContext _context;
        private readonly DbSet<Transmission> _entities;
        public TransmissionRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<Transmission>();
        }
        public void Add(Transmission entity)
        {
            _entities.Add(entity);
        }

        public async Task<Transmission> FindByConditionAsync(Expression<Func<Transmission, bool>> predicate)
        {
            return await _context.Set<Transmission>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Transmission>> GetAllAsync(IEnumerable<Expression<Func<Transmission, object>>> includes = null)
        {
            IQueryable<Transmission> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }
            return await queryable.ToListAsync();
        }

        public async Task<Transmission> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
