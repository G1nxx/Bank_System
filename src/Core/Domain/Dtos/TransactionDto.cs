using Domain.Dtos.BaseDtos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    [Table("Transactions")]
    public class TransactionDto : EntityDto
    {
        [NotNull]
        public string Type {  get; set; }
        [NotNull]
        public string Information { get; set; }
    }
}
