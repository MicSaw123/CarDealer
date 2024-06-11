using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviouslyDamagedController : ApiControllerBase
    {
        private readonly IPreviouslyDamagedService _previouslyDamagedService;

        public PreviouslyDamagedController(IPreviouslyDamagedService previouslyDamagedService)
        {
            _previouslyDamagedService = previouslyDamagedService;
        }

        [HttpGet("GetPreviouslyDamaged")]
        public async Task<IActionResult> GetPreviouslyDamaged()
        {
            var result = await _previouslyDamagedService.GetPreviouslyDamaged();
            return CreateResponse(result);
        }
    }
}
