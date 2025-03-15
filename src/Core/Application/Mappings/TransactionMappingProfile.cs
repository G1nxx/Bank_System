using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.BankDtos;
using Domain.Entities;
using Domain.Entities.Transactions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;

public class TransactionMappingProfile : Profile
{
    public TransactionMappingProfile()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForMember(dst => dst.Type,
                opt => opt.MapFrom(src => Enum.GetName(typeof(TransactionType), src.Type)));

        CreateMap<TransactionDto, Transaction>()
            .ForMember(dst => dst.Type,
                opt => opt.MapFrom(src => Enum.Parse(typeof(TransactionType), src.Type)));
    }
}
