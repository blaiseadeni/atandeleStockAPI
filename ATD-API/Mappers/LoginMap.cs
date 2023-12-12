using ATD_API.Entities;
using ATD_API.Models;
using AutoMapper;

namespace ATD_API.Mappers
{
    public class LoginMap : Profile
    {
        public LoginMap()
        {
            CreateMap<LoginMod, Login>().ReverseMap();
        }
    }
}
