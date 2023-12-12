using ATD_API.Entities;
using AutoMapper;

namespace ATD_API.Mappers
{
    public class PortefeuilleMap : Profile
    {
        public PortefeuilleMap()
        {
            CreateMap<Portefeuille, PortefeuilleMod>().ReverseMap();
        }
    }
}
