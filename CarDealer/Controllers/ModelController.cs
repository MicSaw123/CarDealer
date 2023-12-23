using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("GetModels")]
        public async Task<ActionResult<List<Model>>> GetModelAsync()
        {
            var result = await _modelService.GetModels();
            return Ok(result);
        }

        [HttpGet("GetModelsByManufacturerId")]
        public async Task<ActionResult<List<Model>>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken = default)
        {
            var result = await _modelService.GetModelsByManufacturerIdAsync(manufacturerId, cancellationToken);
            return Ok(result);
        }
    }
}
