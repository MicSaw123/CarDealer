using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IListingService
    {
        public Task<RequestResult> AddListing(AddListingDto listingDto);

        public Task<RequestResult> DeleteListing(int id);

        public Task<RequestResult<IEnumerable<GetListingsDto>>> GetAllListings();

        public Task<RequestResult<GetListingsDto>> GetListingById(int id);

        public Task<RequestResult<List<GetListingsDto>>> GetListingsBySellerId(int id);

        public Task<RequestResult> UpdateListing(AddListingDto addListingDto);
    }
}
