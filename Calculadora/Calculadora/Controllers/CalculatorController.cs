using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Calculadora.Controllers
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

        [HttpGet("soma/{num1}/{num2}")]
        public IActionResult soma(string num1, string num2)
        {

            if(verificarValor(num1) && verificarValor(num2))
            {
                var sum = converterDecimal(num1) + converterDecimal(num2);

                return Ok(sum.ToString());
            }

            return BadRequest("Valor Inválido");
            
        }

        private decimal converterDecimal(string strNumber)
        {

            decimal valordecimal;
            if(decimal.TryParse(strNumber, out valordecimal))
            {
                return valordecimal;
            }

            return 0;
            throw new NotImplementedException();
        }

        private bool verificarValor(string valor)
        {

            double numero;
            bool isNumber = double.TryParse(valor, System.Globalization.NumberStyles.Any, 
                                            System.Globalization.NumberFormatInfo.InvariantInfo,
                                            out numero);

            return isNumber;
            throw new NotImplementedException();
        }

        [HttpGet("subtrair/{num1}/{num2}")]

        public IActionResult subtracao(string num1, string num2)
        {
            if(verificarValor(num1) && verificarValor(num2))
            {
                var subtrair = converterDecimal(num1) - converterDecimal(num2);

                return Ok(subtrair.ToString());
            }

            return BadRequest("Valor Inválido");
        }

        [HttpGet("multiplicar/{num1}/{num2}")]
        public IActionResult multiplicacao(string num1, string num2)
        {
            if(verificarValor(num1) && verificarValor(num2)){
                var multiplicar = converterDecimal(num1) * converterDecimal(num2);
                return Ok(multiplicar.ToString());
            }

            return BadRequest("Valor Inválido");
        }

        [HttpGet("dividir/{num1}/{num2}")]
        public IActionResult divisao(string num1, string num2)
        {
            if(verificarValor(num1) && verificarValor(num2))
            {
                var dividir = converterDecimal(num1) / converterDecimal(num2);
                return Ok(dividir.ToString());
            }
            return BadRequest("Valor Inválido");
        }

        [HttpGet("media/{num1}/{num2}")]
        public IActionResult media(string num1, string num2)
        {
            if(verificarValor(num1) && verificarValor(num2))
            {
                var media = (converterDecimal(num1) + converterDecimal(num2)) / 2;

                return Ok(media.ToString());
            }
            return BadRequest("Valor Inválido");

         
        }
        

        [HttpGet("raiz/{num}")]
        public IActionResult raiz(string num)
        {
            if(verificarValor(num))
            {
                var raiz = Math.Sqrt((double)converterDecimal(num));

               

                return Ok(raiz.ToString());
            }
            return BadRequest("Valor Inválido");
        }
    }
}
