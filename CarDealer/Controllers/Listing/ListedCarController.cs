using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Controllers.Base;
using CarDealer.Domain.Entities.Lisitngs;
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

        [HttpGet("GetListedCars")]
        public async Task<IActionResult> GetListedCars()
        {
            var result = await _listedCarService.GetListedCars();
            return CreateResponse(result);
        }

        [HttpPost("AddListedCar")]
        public async Task<IActionResult> AddListedCar(ListedCar entity)
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
    }
}
