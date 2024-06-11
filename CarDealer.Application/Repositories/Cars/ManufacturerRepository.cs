using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Repositories.Cars
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(IDbContext context) : base(context)
        {
        }
    }
}
