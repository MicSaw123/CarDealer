using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ApiControllerBase
    {
        private readonly IEngineService _engineService;

        public EngineController(IEngineService engineService)
        {
            _engineService = engineService;
        }
        [HttpGet("GetEngines")]
        public async Task<IActionResult> GetEngines()
        {
            var result = await _engineService.GetEngines();
            return CreateResponse(result);
        }
    }
}
