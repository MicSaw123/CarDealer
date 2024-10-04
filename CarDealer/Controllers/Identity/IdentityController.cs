using CarDealer.Application.DataTransferObjects.Dtos.Identity;
using CarDealer.Application.Interfaces.Services.Identity;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Identity
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ApiControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenManagerService _tokenManager;

        public IdentityController(IIdentityService identityService,
            ITokenManagerService tokenManager)
        {
            _identityService = identityService;
            _tokenManager = tokenManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto, CancellationToken cancellationToken)
        {
            return CreateResponse(await _identityService.Register(registerDto));
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            return CreateResponse(await _identityService.Login(loginDto));
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _tokenManager.DeactivateCurrentTokenAsync();
            return NoContent();
        }

        [HttpGet("GetUserInfoById")]
        public async Task<IActionResult> GetUserInfoById(int id)
        {
            return CreateResponse(await _identityService.GetUserInfoById(id));
        }

        [HttpPut("UpdateAccountDetails")]
        public async Task<IActionResult> UpdateAccountDetails([FromBody] UserInfoDto userInfoDto, CancellationToken cancellation)
        {
            return CreateResponse(await _identityService.UpdateAccountDetails(userInfoDto, cancellation));
        }
    }
}
