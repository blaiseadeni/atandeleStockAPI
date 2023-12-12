using ATD_API.Entities;
using ATD_API.Models;
using AutoMapper;

namespace ATD_API.Mappers
{
    public class DepenseMap : Profile
    {
        public DepenseMap()
        {
            CreateMap<DepenseMod, Depense>().ReverseMap();
        }
    }
}
