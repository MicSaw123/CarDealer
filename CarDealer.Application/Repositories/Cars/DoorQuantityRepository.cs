using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Repositories.Cars
{
    public class DoorQuantityRepository : GenericRepository<DoorQuantity>, IDoorQuantityRepository
    {
        public DoorQuantityRepository(IDbContext context) : base(context)
        {
        }
    }
}
