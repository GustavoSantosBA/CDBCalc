using CDBCalc_Domain.Entities;
using CDBCalc_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDBCalc_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMethodServices _methodServices;

        public WeatherForecastController(IMethodServices methodServices)
        {
            _methodServices = methodServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _methodServices.CalculateNetValue(100, 10);
            return Ok(result);
        }
    }
}
