using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.SearchListingsDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.UpdateListingDto;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IListingService
    {
        public Task<RequestResult> AddListing(AddListingDto listingDto);

        public Task<RequestResult> DeleteListing(int id);

        public Task<RequestResult<GetListingsDto>> GetListingById(int id);

        public Task<RequestResult<List<GetListingsDto>>> GetListingsBySellerId(int id);

        public Task<RequestResult> UpdateListing(UpdateListingDto addListingDto, string path);

        public Task<RequestResult<IEnumerable<GetListingsDto>>> DeactivateOldListings();

        public Task<RequestResult<IEnumerable<GetListingsDto>>> GetActiveListings();

        public Task<RequestResult> ChangeListingStatus(int id, bool status);

        public Task<RequestResult<IEnumerable<GetListingsDto>>>
            FilterListings(int sortingId, ListingsSearchConditions searchListingsDto);
    }
}
