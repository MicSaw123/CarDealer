using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivetrainController : ApiControllerBase
    {
        private readonly IDrivetrainService _drivetrainService;

        public DrivetrainController(IDrivetrainService drivetrainService)
        {
            _drivetrainService = drivetrainService;
        }

        [HttpGet("GetDrivetrains")]
        public async Task<IActionResult> GetDrivetrains()
        {
            var result = await _drivetrainService.GetDrivetrains();
            return CreateResponse(result);
        }
    }
}
