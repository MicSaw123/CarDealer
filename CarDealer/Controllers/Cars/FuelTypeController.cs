using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ApiControllerBase
    {
        private readonly IFuelType _fuelType;

        public FuelTypeController(IFuelType fuelType)
        {
            _fuelType = fuelType;
        }
        [HttpGet("GetFuelTypes")]
        public async Task<IActionResult> GetFuelTypes()
        {
            var result = await _fuelType.GetFuelTypes();
            return CreateResponse(result);
        }

    }
}
