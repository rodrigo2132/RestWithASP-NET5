using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var cal = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(cal.ToString());
            }
                
            return BadRequest("Invalid input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var cal = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(cal.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var cal = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(cal.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var cal = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(cal.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var cal = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(cal.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var cal = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(cal.ToString());
            }

            return BadRequest("Invalid input");
        }


        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
                return decimalValue;

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {            
            double number;
            bool isNumber = double.TryParse(strNumber, 
                                            System.Globalization.NumberStyles.Any, 
                                            System.Globalization.NumberFormatInfo.InvariantInfo, 
                                            out number);

            return isNumber;
        }
    }
}
