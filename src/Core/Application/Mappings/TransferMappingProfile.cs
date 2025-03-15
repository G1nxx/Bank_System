using Application.Interfaces.Handlers;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class TransferMappingProfile : Profile
    {
        public TransferMappingProfile() 
        {
            CreateMap<Transfer, TransferDto>();

            CreateMap<TransferDto, Transfer>();
        }
    }
}
