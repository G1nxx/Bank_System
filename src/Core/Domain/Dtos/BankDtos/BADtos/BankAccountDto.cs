using Domain.Dtos.Base;
using Domain.Dtos.BaseDtos;
using Domain.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.BankDtos.BADtos
{
    [Table("BankAccounts")]
    public class BankAccountDto : BABaseDto
    {
        [NotNull, Unique]
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
    }
}
