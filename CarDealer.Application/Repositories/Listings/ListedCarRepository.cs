using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Lisitngs;

namespace CarDealer.Application.Repositories.Listings
{
    public class ListedCarRepository : GenericRepository<ListedCar>, IListedCarRepository
    {
        public ListedCarRepository(IDbContext context) : base(context)
        {
        }
    }
}
