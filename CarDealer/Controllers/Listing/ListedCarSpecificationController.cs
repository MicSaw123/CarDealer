using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Controllers.Base;
using CarDealer.Domain.Entities.Lisitngs;
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

        [HttpGet("GetListedCarSpecifications")]
        public async Task<IActionResult> GetAllListedCarSpecifications()
        {
            var result = await _listedCarSpecificationService.GetListedCarSpecifications();
            return CreateResponse(result);
        }

        [HttpPost("AddListedCarSpecification")]
        public async Task<IActionResult> AddListedCarSpecification(ListedCarSpecification entity)
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
    }
}
