using Microsoft.AspNetCore.Mvc;
using TestApi.Models;
using TestApi.Models.DTOs;
using TestApi.Services.Interfaces;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _humanService;
        public HumanController(IHumanService humanService) 
        {
            _humanService = humanService;
        }

        /// <summary>
        /// Obtiene usuarios de un listado fijo
        /// </summary>
        /// <returns>sss</returns>
        [HttpGet("GetUserMock")]
        public Human[] GetUserMock()
        {
            return _humanService.GetUsersMock();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Response<IEnumerable<HumanResponse>> response = await _humanService.GetAll();
            return response.IsSuccess?StatusCode(response.StatusCode,response.Data):StatusCode(response.StatusCode,response.GetErrorObject());
        }

        [HttpGet("GetHumanById/{humanId}")]
        public async Task<IActionResult> GetHumanById(Guid humanId)
        {
            Response<HumanResponse> response = await _humanService.GetHumanById(humanId);
            return response.IsSuccess ? StatusCode(response.StatusCode, response.Data) : StatusCode(response.StatusCode, response.GetErrorObject());
        }

        [HttpPost("CreateHuman")]
        public async Task<IActionResult> CreateHuman([FromForm] HumanRequest newHuman)
        {
            Response<HumanResponse> response = await _humanService.CreateHuman(newHuman);
            return response.IsSuccess ? StatusCode(response.StatusCode, response.Data) : StatusCode(response.StatusCode, response.GetErrorObject());
        }

        [HttpPut("UpdateHuman/{humanId}")]
        public async Task<IActionResult> Put(Guid humanId, [FromForm] HumanRequest newHuman)
        {
            Response<HumanResponse> response = await _humanService.UpdateHuman(humanId, newHuman);
            return response.IsSuccess ? StatusCode(response.StatusCode, response.Data) : StatusCode(response.StatusCode, response.GetErrorObject());
        }
    }
}
