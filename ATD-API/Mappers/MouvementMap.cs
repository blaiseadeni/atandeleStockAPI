using ATD_API.Entities;
using ATD_API.Models;
using AutoMapper;

namespace ATD_API.Mappers
{
    public class MouvementMap : Profile
    {
        public MouvementMap()
        {
            CreateMap<Mouvement, MouvementMod>().ReverseMap();
        }
    }
}
