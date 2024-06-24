using CarDealer.Application.Interfaces.Services.GetBasicProperties;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.GetBasicProperties
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBasicPropertiesController : ApiControllerBase
    {
        private readonly IGetBasicPropertiesService _getBasicPropertiesService;

        public GetBasicPropertiesController(IGetBasicPropertiesService getBasicPropertiesService)
        {
            _getBasicPropertiesService = getBasicPropertiesService;
        }

        [HttpGet("GetBasicProperties")]
        public async Task<IActionResult> GetBasicProperties()
        {
            var result = await _getBasicPropertiesService.GetBasicProperties();
            return CreateResponse(result);
        }
    }
}
