using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ATD_API.Entities;

namespace ATD_API.Mappers
{
    public class StockMap : Profile
    {
        public StockMap()
        {
            CreateMap<Stock, StockMod>().ReverseMap();
        }
    }
}