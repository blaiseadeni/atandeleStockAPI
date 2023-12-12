using ATD_API.Entities;
using ATD_API.Models;
using AutoMapper;

namespace ATD_API.Mappers
{
    public class RoleMap : Profile
    {
        public RoleMap()
        {
            CreateMap<RoleMod, Role>().ReverseMap();
        }
    }
}
