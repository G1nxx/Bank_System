using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Users;
using Domain.Enums;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Mapping
{
    public class BankMappingProfile : Profile
    {
        public BankMappingProfile()
        {
            CreateMap<Bank, BankDto>()
                .ForMember(dst => dst.Type,
                    opt => opt.MapFrom(src =>
                        src.Type == CompanyType.None ? "None" :
                        src.Type == CompanyType.IP ? "IP" :
                        src.Type == CompanyType.OOO ? "OOO" :
                        src.Type == CompanyType.OAO ? "OAO" :
                        src.Type == CompanyType.ODO ? "ODO" : "ZAO"));
                //.ForMember(dst => dst.ClientIds,
                //    opt => opt.Ignore()) // или .Ignore()
                //.ForMember(dst => dst.CreditIds,
                //    opt => opt.Ignore()); // или .Ignore()

            CreateMap<BankDto, Bank>()
                .ForMember(dst => dst.Type,
                    opt => opt.MapFrom(src =>
                        src.Type == "None" ? CompanyType.None :
                        src.Type == "IP" ? CompanyType.IP :
                        src.Type == "OOO" ? CompanyType.OOO :
                        src.Type == "OAO" ? CompanyType.OAO :
                        src.Type == "ODO" ? CompanyType.ODO : CompanyType.ZAO));
                //.ForMember(dst => dst.Accounts, opt => opt.Ignore())
                //.ForMember(dst => dst.Users, opt => opt.Ignore());
        }
    }
}
