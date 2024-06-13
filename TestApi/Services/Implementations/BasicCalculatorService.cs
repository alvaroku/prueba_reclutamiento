using TestApi.Models.BasicCalculator;
using TestApi.Models.Humans.DTOs;
using TestApi.Services.Interfaces;

namespace TestApi.Services.Implementations
{
    public class BasicCalculatorService : IBasicCalculatorService
    {
        public Response<decimal> GetOperationResult(decimal firstNumber, decimal secondNumber, OperationEnum operation)
        {
            Response<decimal> response = new Response<decimal>();
            response.StatusCode = 200;
            response.IsSuccess = true;

            switch (operation)
            {
                case OperationEnum.Addition:
                    response.Data = firstNumber + secondNumber;
                    break;
                case OperationEnum.Subtraction:
                    response.Data = firstNumber - secondNumber;
                    break;
                case OperationEnum.Multiplication:
                    response.Data = firstNumber* secondNumber;
                    break;
                case OperationEnum.Division:
                    if (secondNumber == 0)
                    {
                        response.StatusCode = 400;
                        response.IsSuccess = false;
                        response.ErrorMessage = "No se puede dividir entre 0.";
                        return response;
                    }
                    response.Data = firstNumber / secondNumber;
                    break;
                default:
                    response.IsSuccess = false;
                    response.ErrorMessage = "Operación no válida.";
                    response.StatusCode = 400;
                    break;
            }
            return response;
        }
    }
}
