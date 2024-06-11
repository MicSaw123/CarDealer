using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarConditionController : ApiControllerBase
    {
        private readonly ICarConditionService _carConditionService;

        public CarConditionController(ICarConditionService carConditionService)
        {
            _carConditionService = carConditionService;
        }

        [HttpGet("GetCarConditions")]
        public async Task<IActionResult> GetCarConditions()
        {
            var result = await _carConditionService.GetCarConditions();
            return CreateResponse(result);
        }

    }
}
