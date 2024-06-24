using CarDealer.Application.Interfaces.Services.Address;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Address
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ApiControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("Countries")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _addressService.GetCountries();
            return CreateResponse(result);
        }

        [HttpGet("Cities")]
        public async Task<IActionResult> GetCitiesByCountryId(int countryId, CancellationToken cancellationToken = default)
        {
            var result = await _addressService.GetCityByCountryId(countryId, cancellationToken);
            return CreateResponse(result);
        }
    }
}
