using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Database;
using Microsoft.EntityFrameworkCore;
using CarDealer.Domain.Entities;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IDbContext _context;

        private readonly DbSet<Car> _entities;

        public CarRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<Car>();
        }

        public void Add(Car entity)
        {
            _entities.Add(entity);
        }

        public async Task<Car> FindByConditionAsync(Expression<Func<Car, bool>> predicate)
        {
            return await _context.Set<Car>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Car>> GetAllAsync(IEnumerable<Expression<Func<Car, object>>> includes = default)
        {
            IQueryable<Car> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }

            return await queryable.ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }

    }
}
