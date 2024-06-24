using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Listing
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListedCarController : ApiControllerBase
    {
        private readonly IListedCarService _listedCarService;

        public ListedCarController(IListedCarService listedCarService)
        {
            _listedCarService = listedCarService;
        }

        [HttpPost("AddListedCar")]
        public async Task<IActionResult> AddListedCar(AddListedCarDto entity)
        {
            var result = await _listedCarService.AddListedCar(entity);
            return CreateResponse(result);
        }

        [HttpDelete("DeleteListedCar")]
        public async Task<IActionResult> DeleteListedCar(int id)
        {
            var result = await _listedCarService.DeleteListedCar(id);
            return CreateResponse(result);
        }

        [HttpGet("GetListedCarById")]
        public async Task<IActionResult> GetListedCarById(int id)
        {
            var result = await _listedCarService.GetListedCarById(id);
            return CreateResponse(result);
        }
    }
}
