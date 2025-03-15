using Domain.Dtos.BankDtos.BADtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Mapping
{
    public class BAMappingProfile : Profile
    {
        public BAMappingProfile()
        {
            CreateMap<BankAccount, BankAccountDto>()
                .ForMember(dst => dst.Status,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(AStatusType), src.Status)))
                .ForMember(dst => dst.Currency,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(CurrencyType), src.Currency)));

            CreateMap<BankAccountDto, BankAccount>()
                .ForMember(dst => dst.Status,
                    opt => opt.MapFrom(src => Enum.Parse(typeof(AStatusType), src.Status)))
                .ForMember(dst => dst.Currency,
                    opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.Currency)));
        }
    }
}
