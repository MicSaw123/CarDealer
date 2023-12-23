using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelType _fuelType;

        public FuelTypeController(IFuelType fuelType)
        {
            _fuelType = fuelType;
        }
        [HttpGet("GetFuelTypes")]
        public async Task<ActionResult<List<FuelType>>> GetFuelTypes()
        {
            var result = await _fuelType.GetFuelTypes();
            return Ok(result);
        }

    }
}
