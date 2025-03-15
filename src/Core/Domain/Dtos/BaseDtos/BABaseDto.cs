using Domain.Dtos.BaseDtos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Base
{
    [Table("BABases")]
    public class BABaseDto : EntityDto
    {
        [NotNull]
        public string AccountName { get; set; }
        [NotNull]
        public string Currency { get; set; }
        [NotNull]
        public uint UserId { get; set; }
        [NotNull]
        public uint BankId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
