using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Repositories.Generic;

namespace CarDealer.Application.Repositories.Listings
{
    public class ListingRepository : GenericRepository<Domain.Entities.Lisitngs.Listing>, IListingRepository
    {
        public ListingRepository(IDbContext context) : base(context)
        {
        }
    }
}
