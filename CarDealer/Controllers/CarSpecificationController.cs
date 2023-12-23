using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarSpecificationController : ControllerBase
    {
        private readonly ICarSpecificationService _carSpecificationService;

        public CarSpecificationController(ICarSpecificationService carSpecificationService)
        {
            _carSpecificationService = carSpecificationService;
        }
        [HttpGet("GetCarSpecifications")]
        public async Task<ActionResult<List<CarSpecification>>> GetCarSpecifications()
        {
            var result = await _carSpecificationService.GetCarSpecifications();
            return Ok(result);
        }
    }
}
