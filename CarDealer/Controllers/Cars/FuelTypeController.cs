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
        private readonly IFuelTypeService _fuelTypeService;

        public FuelTypeController(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        [HttpGet("GetFuelTypes")]
        public async Task<IActionResult> GetFuelTypeDtos()
        {
            var result = await _fuelTypeService.GetFuelTypeDtos();
            return CreateResponse(result);
        }
    }
}
