using ATD_API.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATD_API.Mappers
{
    public class FournisseurMap : Profile
    {
        public FournisseurMap()
        {
            CreateMap<Fournisseur, FournisseurMod>().ReverseMap();
        }
    }
}