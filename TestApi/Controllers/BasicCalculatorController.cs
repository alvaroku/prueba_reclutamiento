using Microsoft.AspNetCore.Mvc;
using TestApi.Models.BasicCalculator;
using TestApi.Models.Humans.DTOs;
using TestApi.Services.Interfaces;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicCalculatorController : ControllerBase
    {
        private readonly IBasicCalculatorService _basicCalculatorService;
        public BasicCalculatorController(IBasicCalculatorService basicCalculatorService) 
        {
            _basicCalculatorService = basicCalculatorService;
        }
       
        [HttpPost("ExecuteMathOperation")]
        public IActionResult ExecuteMathOperationPost([FromForm] decimal firstNumber, [FromForm] decimal secondNumber, [FromForm] OperationEnum operation)
        {
            Response<decimal> response =  _basicCalculatorService.GetOperationResult(firstNumber,secondNumber,operation);
            return response.IsSuccess? StatusCode(response.StatusCode,response.Data) : StatusCode(response.StatusCode, response.GetErrorObject());
        }

        [HttpGet("ExecuteMathOperationHeader")]
        public IActionResult ExecuteMathOperationHeader([FromHeader] decimal firstNumber, [FromHeader] decimal secondNumber, [FromHeader] OperationEnum operation)
        {
            Response<decimal> response = _basicCalculatorService.GetOperationResult(firstNumber, secondNumber, operation);
            return response.IsSuccess ? StatusCode(response.StatusCode, response.Data) : StatusCode(response.StatusCode, response.GetErrorObject());
        }
    }
}
