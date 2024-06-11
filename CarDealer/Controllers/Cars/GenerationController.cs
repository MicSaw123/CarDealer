using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerationController : ApiControllerBase
    {
        private readonly IGenerationService _generationService;

        public GenerationController(IGenerationService generationService)
        {
            _generationService = generationService;
        }

        [HttpGet("GetGenerationsByModelId")]
        public async Task<IActionResult> GetGenerationsByModelIdAsync(int modelId, CancellationToken cancellationToken = default)
        {
            var result = await _generationService.GetGenerationsByModelIdAsync(modelId, cancellationToken);
            return CreateResponse(result);
        }
    }
}
