using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Controllers.Base;
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

        [HttpPost("AddIdentifiedVehicle")]
        public async Task<IActionResult> AddIdentifiedVehicle(AddIdentifiedVehiclesDto entity)
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

        [HttpGet("GetIdentifiedVehicleById")]
        public async Task<IActionResult> GetIdentifiedVehicleById(int id)
        {
            var result = await _identifiedVehiclesService.GetIdentifiedVehicleId(id);
            return CreateResponse(result);
        }

    }
}
