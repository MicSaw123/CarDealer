using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.SearchListingsDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.UpdateListingDto;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Listing
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ApiControllerBase
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpPost("AddListing")]
        public async Task<IActionResult> AddListing([FromBody] AddListingDto listingDto)
        {
            return CreateResponse(await _listingService.AddListing(listingDto));
        }

        [HttpDelete("DeleteListing")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            var result = await _listingService.DeleteListing(id);
            return CreateResponse(result);
        }

        [HttpGet("GetListingById")]
        public async Task<IActionResult> GetListingById(int id)
        {
            var result = await _listingService.GetListingById(id);
            return CreateResponse(result);
        }

        [HttpGet("GetListingsBySellerId")]
        public async Task<IActionResult> GetListingsBySellerId(int id)
        {
            var result = await _listingService.GetListingsBySellerId(id);
            return CreateResponse(result);
        }

        [HttpPut("UpdateListing")]
        public async Task<IActionResult> UpdateListing([FromBody] UpdateListingDto updateListingDto, string path)
        {
            return CreateResponse(await _listingService.UpdateListing(updateListingDto, path));
        }

        [HttpGet("GetActiveListings")]
        public async Task<IActionResult> GetActiveListings()
        {
            return CreateResponse(await _listingService.GetActiveListings());
        }

        [HttpPut("ChangeListingStatus")]
        public async Task<IActionResult> ChangeListingStatus([FromBody] int id, bool status)
        {
            return CreateResponse(await _listingService.ChangeListingStatus(id, status));
        }

        [HttpPost("FilterListings")]
        public async Task<IActionResult> FilterListings(int sortingId, [FromBody] ListingsSearchConditions searchListingsDto)
        {
            return CreateResponse(await _listingService.FilterListings(sortingId, searchListingsDto));
        }
    }
}
