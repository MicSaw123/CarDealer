
using CarDealer.Application.DataTransferObjects.Dtos.Listing;
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

        public ListingController(IListingService listingService,
            IImageService imageService)
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
        public async Task<IActionResult> AddListing(ListingDto listingDto,
           [FromForm] List<IFormFile> images)
        {
            return CreateResponse(await _listingService.AddListing(listingDto, images));
        }

        [HttpDelete("DeleteListing")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            var result = await _listingService.DeleteListing(id);
            return CreateResponse(result);
        }
    }
}
