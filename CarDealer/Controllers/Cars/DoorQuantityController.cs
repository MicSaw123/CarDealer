using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorQuantityController : ApiControllerBase
    {
        private readonly IDoorQuantityService _doorQuantityService;

        public DoorQuantityController(IDoorQuantityService doorQuantityService)
        {
            _doorQuantityService = doorQuantityService;
        }

        [HttpGet("GetDoorQuantities")]
        public async Task<IActionResult> GetDoorQuantities()
        {
            var result = await _doorQuantityService.GetDoorQuantities();
            return CreateResponse(result);
        }
    }
}
