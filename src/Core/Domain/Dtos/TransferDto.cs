using Domain.Dtos.BaseDtos;
using Domain.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{

    [Table("Transfers")]
    public class TransferDto : EntityDto
    {
        public uint RecipientBankAccountId { get; set; }
        public uint ReceiverBankAccountId { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
