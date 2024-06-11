using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Controllers.Base;
using CarDealer.Domain.Entities.Lisitngs;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Listing
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentifiedVehiclesController : ApiControllerBase
    {
        private readonly IIdentifiedVehiclesService _identifiedVehiclesService;

        public IdentifiedVehiclesController(IIdentifiedVehiclesService identifiedVehiclesService)
        {
            _identifiedVehiclesService = identifiedVehiclesService;
        }

        [HttpGet("GetIdentifiedVehicles")]
        public async Task<IActionResult> GetIdentifiedVehicles()
        {
            var result = await _identifiedVehiclesService.GetIdentifiedVehicles();
            return CreateResponse(result);
        }

        [HttpPost("AddIdentifiedVehicle")]
        public async Task<IActionResult> AddIdentifiedVehicle(IdentifiedVehicles entity)
        {
            var result = await _identifiedVehiclesService.AddIdentifiedVehicle(entity);
            return CreateResponse(result);
        }
        [HttpDelete("DeleteIdentifiedVehicle")]
        public async Task<IActionResult> DeleteIdentifiedVehicle(int id)
        {
            var result = await _identifiedVehiclesService.DeleteIdentifiedVehicle(id);
            return CreateResponse(result);
        }

    }
}
