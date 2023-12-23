using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerationController : ControllerBase
    {
        private readonly IGenerationService _generationService;

        public GenerationController(IGenerationService generationService)
        {
            _generationService = generationService;
        }
        [HttpGet("GetGenerations")]
        public async Task<ActionResult<List<Generation>>> GetGenerations()
        {
            var result = await _generationService.GetGenerations();
            return Ok(result);
        }

        [HttpGet("GetGenerationsByModelId")]
        public async Task<ActionResult<List<Generation>>> GetGenerationsByModelIdAsync(int modelId, CancellationToken cancellationToken = default)
        {
            var result = await _generationService.GetGenerationsByModelIdAsync(modelId, cancellationToken);
            return Ok(result);
        }
    }
}
