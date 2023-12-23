using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly IDbContext _context;

        private readonly DbSet<Model> _entities;
        public ModelRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<Model>();
        }

        public void Add(Model entity)
        {
            _entities.Add(entity);
        }

        public async Task<Model> FindByConditionAsync(Expression<Func<Model, bool>> predicate)
        {
            return await _context.Set<Model>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Model>> GetAllAsync(IEnumerable<Expression<Func<Model, object>>> includes = null)
        {
            IQueryable<Model> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }
            return await queryable.ToListAsync();
        }

        public async Task<Model> GetByIdAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Model>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken = default)
        {
            return await _entities.Where(model => model.ManufacturerId == manufacturerId).ToListAsync(cancellationToken);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }


    }
}
