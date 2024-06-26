﻿using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : ApiControllerBase
    {
        private readonly ICarTypeService _carTypeService;

        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }
        [HttpGet("GetCarTypes")]
        public async Task<IActionResult> GetCarTypes()
        {
            var result = await _carTypeService.GetCarTypes();
            return CreateResponse(result);
        }
    }
}
