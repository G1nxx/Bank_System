using Domain.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dst => dst.Role,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(RoleType), src.Role)));

            CreateMap<UserDto, User>()
                .ForMember(dst => dst.Role,
                    opt => opt.MapFrom(src => Enum.Parse(typeof(RoleType), src.Role)));
        }
    }
}
