using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly IDbContext _context;

        private readonly DbSet<FuelType> _fuelTypes;
        public FuelTypeRepository(IDbContext context)
        {
            _context = context;
            _fuelTypes = context.Set<FuelType>();
        }
        public void Add(FuelType entity)
        {
            _fuelTypes.Add(entity);
        }

        public async Task<FuelType> FindByConditionAsync(Expression<Func<FuelType, bool>> predicate)
        {
            return await _context.Set<FuelType>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<FuelType>> GetAllAsync(IEnumerable<Expression<Func<FuelType, object>>> includes = null)
        {
            IQueryable<FuelType> queryable = _fuelTypes.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }
            return await queryable.ToListAsync();
        }

        public async Task<FuelType> GetByIdAsync(int id)
        {
            return await _fuelTypes.SingleOrDefaultAsync(ft => ft.Id == id);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
