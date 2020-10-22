using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxService.Web.Controllers
{
    using Domain.Calcaulator;
    using Domain.Vat.Exceptions;
    using Model.Api.Calcualte;

    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }


        [HttpPost]
        [Route("api/calculator/calculate")]
        public IActionResult Calculate(List<CalculatePostModel> model)
        {
            try
            {
                var result = _calculator.CalculateVat(model);
                return Ok(result);
            }
            catch (VatRateNotAvailableException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }

        
    }
}
