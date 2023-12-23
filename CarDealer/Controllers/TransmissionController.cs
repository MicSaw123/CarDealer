using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {
        private readonly ITransmissionService _transmissionService;

        public TransmissionController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }
        [HttpGet("GetTransmissions")]
        public async Task<ActionResult<List<Transmission>>> GetTransmissions()
        {
            var result = await _transmissionService.GetTransmissions();
            return Ok(result);
        }
    }
}
