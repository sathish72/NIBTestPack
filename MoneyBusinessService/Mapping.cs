using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessService.DTOs;
using BusinessService.Entities;

namespace MoneyBusinessService
{
    public class Mapping : Profile
    {
        protected Mapping()
        {
            CreateMap<LoanTracking_Money, MoneyDTO>().ReverseMap();
        }
    }
}
