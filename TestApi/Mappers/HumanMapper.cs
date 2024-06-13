using AutoMapper;
using TestApi.Models;
using TestApi.Models.DTOs;

namespace TestApi.Mappers
{
    public class HumanMapper:Profile
    {
        public HumanMapper()
        {
            CreateMap<Human, HumanRequest>().ReverseMap();
            CreateMap<Human, HumanResponse>().ReverseMap();  
        }
    }
}
