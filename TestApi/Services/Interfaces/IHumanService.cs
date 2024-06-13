using TestApi.Models;
using TestApi.Models.DTOs;

namespace TestApi.Services.Interfaces
{
    public interface IHumanService
    {
        Human[] GetUsersMock();
        Task<Response<IEnumerable<HumanResponse>>> GetAll();
        Task<Response<HumanResponse>> GetHumanById(Guid humanId);
        Task<Response<HumanResponse>> CreateHuman(HumanRequest newHuman);
        Task<Response<HumanResponse>> UpdateHuman(Guid humanId,HumanRequest newHuman);
    }
}
