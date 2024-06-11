using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Repositories.Cars
{
    public class EngineRepository : GenericRepository<Engine>, IEngineRepository
    {
        public EngineRepository(IDbContext context) : base(context)
        {
        }
    }
}
