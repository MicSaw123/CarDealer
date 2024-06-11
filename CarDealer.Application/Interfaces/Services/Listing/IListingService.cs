using CarDealer.Application.DataTransferObjects.Dtos.Listing;
using Microsoft.AspNetCore.Http;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IListingService
    {
        public Task<RequestResult> AddListing(ListingDto listingDto, List<IFormFile> images);

        public Task<RequestResult> DeleteListing(int id);

        public Task<RequestResult<IEnumerable<Domain.Entities.Lisitngs.Listing>>> GetAllListings();
    }
}
