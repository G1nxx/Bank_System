using Domain.Dtos.BankDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Application.Mapping
{
    public class BankMappingProfile : Profile
    {
        public BankMappingProfile()
        {
            CreateMap<Bank, BankDto>()
                .ForMember(dst => dst.Type,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(CompanyType), src.Type)));

            CreateMap<BankDto, Bank>()
                .ForMember(dst => dst.Type,
                    opt => opt.MapFrom(src => Enum.Parse(typeof(CompanyType), src.Type)));
        }
    }
}
