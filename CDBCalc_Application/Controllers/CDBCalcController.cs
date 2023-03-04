using CDBCalc_Domain.Entities;
using CDBCalc_Domain.Interfaces.Services;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CDBCalc_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CdbCalcController : ControllerBase
    {
        private readonly IMethodServices _methodServices;

        public CdbCalcController(IMethodServices methodServices)
        {
            _methodServices = methodServices;
        }

        [HttpGet("calculateNetValue")]
        public IActionResult Get([FromQuery] decimal presentValue, int period)
        {
            var result = _methodServices.CalculateNetValue(presentValue, period);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetReport()
        {
            var report = new XtraReport();
            // Configurar o relatório aqui
            using (var ms = new MemoryStream())
            {
                report.ExportToPdf(ms);
                return File(ms.ToArray(), "application/pdf");
            }
        }
    }
}
