using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarSpecificationController : ApiControllerBase
    {
        private readonly ICarSpecificationService _carSpecificationService;

        public CarSpecificationController(ICarSpecificationService carSpecificationService)
        {
            _carSpecificationService = carSpecificationService;
        }
        [HttpGet("GetCarSpecifications")]
        public async Task<IActionResult> GetCarSpecifications()
        {
            var result = await _carSpecificationService.GetCarSpecifications();
            return CreateResponse(result);
        }
    }
}
