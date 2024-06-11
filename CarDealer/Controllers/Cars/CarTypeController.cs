using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using CarDealer.Domain.Entities.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : ApiControllerBase
    {
        private readonly ICarTypeService _carTypeService;

        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }
        [HttpGet("GetCarTypes")]
        public async Task<IActionResult> GetCarTypes()
        {
            var result = await _carTypeService.GetCarTypes();
            return CreateResponse(result);
        }

        [HttpPost("AddCarType")]
        public async Task<IActionResult> AddCarType([FromBody] CarType entity)
        {
            var result = await _carTypeService.Add(entity);
            return CreateResponse(result);
        }

        [HttpDelete("DeleteCarType")]
        public async Task<IActionResult> DeleteCarType(int id)
        {
            var result = await _carTypeService.DeleteCarType(id);
            return CreateResponse(result);
        }
    }
}
