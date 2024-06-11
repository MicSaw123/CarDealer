using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Lisitngs;

namespace CarDealer.Application.Repositories.Listings
{
    public class ListedCarSpecificationRepository : GenericRepository<ListedCarSpecification>, IListedCarSpecificationRepository
    {
        public ListedCarSpecificationRepository(IDbContext context) : base(context)
        {
        }
    }
}
