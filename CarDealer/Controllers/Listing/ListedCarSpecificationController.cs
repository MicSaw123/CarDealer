using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Listing
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListedCarSpecificationController : ApiControllerBase
    {
        private readonly IListedCarSpecificationService _listedCarSpecificationService;

        public ListedCarSpecificationController(IListedCarSpecificationService listedCarSpecificationService)
        {
            _listedCarSpecificationService = listedCarSpecificationService;
        }

        [HttpPost("AddListedCarSpecification")]
        public async Task<IActionResult> AddListedCarSpecification(AddListedCarSpecificationDto entity)
        {
            var result = await _listedCarSpecificationService.AddListedCarSpecification(entity);
            return CreateResponse(result);
        }

        [HttpDelete("DeleteListedCarSpecification")]
        public async Task<IActionResult> DeleteListedCarSpecification(int id)
        {
            var result = await _listedCarSpecificationService.DeleteListedCarSpecification(id);
            return CreateResponse(result);
        }

        [HttpGet("GetListedCarSpecificationById")]
        public async Task<IActionResult> GetListedCarSpecificationById(int id)
        {
            var result = await _listedCarSpecificationService.GetListedCarSpecificationById(id);
            return CreateResponse(result);
        }
    }
}
