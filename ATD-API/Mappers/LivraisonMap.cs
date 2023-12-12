using ATD_API.Entities;
using AutoMapper;

namespace ATD_API.Mappers
{
    public class LivraisonMap : Profile
    {
        public LivraisonMap()
        {
            CreateMap<Livraison, LivraisonMod>().ReverseMap();
        }
    }
}
