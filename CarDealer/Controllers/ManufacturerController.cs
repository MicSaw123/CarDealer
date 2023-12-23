using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet("GetManufacturers")]
        public async Task<ActionResult<List<Manufacturer>>> GetManufacturers()
        {
            var result = await _manufacturerService.GetManufacturers();
            return Ok(result);
        }
    }
}