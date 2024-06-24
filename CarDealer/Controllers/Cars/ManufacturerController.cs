using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ApiControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [AllowAnonymous]
        [HttpGet("GetManufacturers")]
        public async Task<IActionResult> GetManufacturerDtos()
        {
            var result = await _manufacturerService.GetManufacturerDtos();
            return CreateResponse(result);
        }
    }
}