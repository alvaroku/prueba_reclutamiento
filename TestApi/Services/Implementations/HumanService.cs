using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApi.Models.Humans;
using TestApi.Models.Humans.DB;
using TestApi.Models.Humans.DTOs;
using TestApi.Services.Interfaces;

namespace TestApi.Services.Implementations
{
    public class HumanService : IHumanService
    {
        private readonly HumanDBContext _dbContext;
        private readonly IMapper _mapper;
        public HumanService(HumanDBContext humanDBContext, IMapper mapper)
        {
            _dbContext = humanDBContext;
            _mapper = mapper;
        }

        public Human[] GetUsersMock()
        {
            return HumanList.Humans;
        }

        public async Task<Response<IEnumerable<HumanResponse>>> GetAll()
        {
            Response<IEnumerable<HumanResponse>> response = new Response<IEnumerable<HumanResponse>>();
            response.StatusCode = 200;
            response.IsSuccess = true;

            response.Data = await _dbContext.Humans.Select(h => new HumanResponse
            {
                Id = h.Id,
                Age = h.Age,
                Height = h.Height,
                Name = h.Name,
                Sex = h.Sex,
                Weight = h.Weight,
            }).ToListAsync();
           
            return response;
        }

        public async Task<Response<HumanResponse>> GetHumanById(Guid humanId)
        {
            Response<HumanResponse> response;
            Human? human = await _dbContext.Humans.FindAsync(humanId);

            if(human is null)
            {
                response = new Response<HumanResponse>()
                {
                    ErrorMessage = "El usuario buscado no existe.",
                    StatusCode = 404,
                };
                return response;
            }

            response = new Response<HumanResponse>()
            {
                Data = _mapper.Map<HumanResponse>(human),
                StatusCode = 200,
                IsSuccess = true
            };

            return response;
        }

        public async Task<Response<HumanResponse>> CreateHuman(HumanRequest newHuman)
        {
            Response<HumanResponse> response;

            Human human = new Human
            {
                Age = newHuman.Age,
                Height = newHuman.Height,
                Name = newHuman.Name,
                Sex = newHuman.Sex,
                Weight = newHuman.Weight
            };

            await _dbContext.Humans.AddAsync(human);
            await _dbContext.SaveChangesAsync();

            response = new Response<HumanResponse>
            {
                Data = _mapper.Map<HumanResponse>(human),
                StatusCode = 201,
                IsSuccess = true
            };
            return response;
        }

        public async Task<Response<HumanResponse>> UpdateHuman(Guid humanId, HumanRequest newHuman)
        {
            Response<HumanResponse> response;

            Human? humanToUpdate = await _dbContext.Humans.FindAsync(humanId);
            if (humanToUpdate is null)
            {
                response = new Response<HumanResponse>
                {
                    ErrorMessage = "El usuario que se requiere actualizar no existe.",
                    StatusCode = 404
                };
                return response;
            }

            humanToUpdate.Age = newHuman.Age;
            humanToUpdate.Height = newHuman.Height;
            humanToUpdate.Name = newHuman.Name;
            humanToUpdate.Sex = newHuman.Sex;
            humanToUpdate.Weight = newHuman.Weight;

            _dbContext.Humans.Update(humanToUpdate);
            await _dbContext.SaveChangesAsync();

            response = new Response<HumanResponse>
            {
                Data = _mapper.Map<HumanResponse>(humanToUpdate),
                StatusCode = 200,
                IsSuccess = true

            };
            return response;
        }
    }
}
