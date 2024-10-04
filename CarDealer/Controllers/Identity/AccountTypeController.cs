using CarDealer.Application.Interfaces.Services.Identity;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ApiControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;

        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        [HttpGet("GetAccountTypes")]
        public async Task<IActionResult> GetAccountTypes()
        {
            return CreateResponse(await _accountTypeService.GetAccountTypes());
        }
    }
}
