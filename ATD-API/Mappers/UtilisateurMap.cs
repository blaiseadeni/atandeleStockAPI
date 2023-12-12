using ATD_API.Entities;
using ATD_API.Models;
using AutoMapper;

namespace ATD_API.Mappers
{
    public class UtilisateurMap : Profile
    {
        public UtilisateurMap()
        {
            CreateMap<UtilisateurMod, Utilisateur>().ReverseMap();
        }
    }
}
