using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Lisitngs;

namespace CarDealer.Application.Repositories.Listings
{
    public class IdentifiedVehiclesRepository : GenericRepository<IdentifiedVehicles>, IIdentifiedVehiclesRepository
    {
        public IdentifiedVehiclesRepository(IDbContext context) : base(context)
        {
        }
    }
}
