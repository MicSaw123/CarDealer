using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly IDbContext _context;

        private readonly DbSet<CarType> _entities;
        public CarTypeRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<CarType>();
        }

        public void Add(CarType entity)
        {
            _entities.Add(entity);
        }

        public async Task<CarType> FindByConditionAsync(Expression<Func<CarType, bool>> predicate)
        {
            return await _context.Set<CarType>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<CarType>> GetAllAsync(IEnumerable<Expression<Func<CarType, object>>> includes = null)
        {
            IQueryable<CarType> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }
            return await queryable.ToListAsync();
        }

        public async Task<CarType> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(ct => ct.Id == id);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
