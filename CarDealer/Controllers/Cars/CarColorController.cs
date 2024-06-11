using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarColorController : ApiControllerBase
    {
        private readonly ICarColorService _carColorService;

        public CarColorController(ICarColorService carColorService)
        {
            _carColorService = carColorService;
        }

        [HttpGet("GetCarColors")]
        public async Task<IActionResult> GetCarColors()
        {
            var result = await _carColorService.GetCarColors();
            return CreateResponse(result);
        }
    }
}
