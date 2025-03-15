using Domain.Dtos.BankDtos.BADtos;
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
    public class RCBAMappingProfile : Profile
    {
        public RCBAMappingProfile()
        {
            CreateMap<RCBA, RCBADto>()
                .ForMember(dst => dst.Currency,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(CurrencyType), src.Currency)))
                .ForMember(dst => dst.IsApproved,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(RStatusType), src.IsApproved)));

            CreateMap<RCBADto, RCBA>()
                .ForMember(dst => dst.Currency,
                    opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.Currency)))
                .ForMember(dst => dst.IsApproved,
                    opt => opt.MapFrom(src => Enum.Parse(typeof(RStatusType), src.IsApproved)));
        }
    }
}
