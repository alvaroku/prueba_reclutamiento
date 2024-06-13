using AutoMapper;
using TestApi.Models.Humans;
using TestApi.Models.Humans.DTOs;

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
