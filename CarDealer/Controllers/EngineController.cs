using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IEngineService _engineService;

        public EngineController(IEngineService engineService)
        {
            _engineService = engineService;
        }
        [HttpGet("GetEngines")]
        public async Task<ActionResult<List<Engine>>> GetEngines()
        {
            var result = await _engineService.GetEngines();
            return Ok(result);
        }
    }
}
