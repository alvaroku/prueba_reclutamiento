using TestApi.Models.BasicCalculator;
using TestApi.Models.Humans.DTOs;

namespace TestApi.Services.Interfaces
{
    public interface IBasicCalculatorService
    {
        Response<decimal> GetOperationResult(decimal firstNumber, decimal secondNumber, OperationEnum operation);
    }
}
