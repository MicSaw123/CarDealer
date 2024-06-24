using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
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

        [HttpGet("GetListings")]
        public async Task<IActionResult> GetAllListings()
        {
            var result = await _listingService.GetAllListings();
            return CreateResponse(result);
        }

        [HttpPost("AddListing")]
        public async Task<IActionResult> AddListing(AddListingDto listingDto)
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
        public async Task<IActionResult> UpdateListing(AddListingDto addListingDto)
        {
            var result = await _listingService.UpdateListing(addListingDto);
            return CreateResponse(result);
        }
    }
}
