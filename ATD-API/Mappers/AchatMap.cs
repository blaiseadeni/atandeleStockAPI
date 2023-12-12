using ATD_API.Entities;
using ATD_API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATD_API.Mappers
{
    public class AchatMap : Profile
    {
        public AchatMap()
        {
            CreateMap<Achat, AchatModel>().ReverseMap();
        }
    }
}