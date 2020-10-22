using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxService.Web.Controllers
{
    using Domain.Calcaulator;
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
        public List<CalculatedItemWithVatDto> Calculate(List<CalculatePostModel> model)
        {
            var result = _calculator.CalculateVat(model);
            return result;
        }

        
    }
}
