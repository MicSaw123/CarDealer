using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly IDbContext _context;

        private readonly DbSet<Manufacturer> _entities;

        public ManufacturerRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<Manufacturer>();
        }
        public void Add(Manufacturer entity)
        {
            _entities.Add(entity);
        }

        public async Task<Manufacturer> FindByConditionAsync(Expression<Func<Manufacturer, bool>> predicate)
        {
            return await _context.Set<Manufacturer>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync(IEnumerable<Expression<Func<Manufacturer, object>>> includes = null)
        {
            IQueryable<Manufacturer> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }
            return await queryable.ToListAsync();
        }

        public async Task<Manufacturer> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
