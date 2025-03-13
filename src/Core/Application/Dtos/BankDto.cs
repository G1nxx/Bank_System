using Domain.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    [Table("Banks")]
    public class BankDto
    {
        [PrimaryKey, AutoIncrement, Indexed, NotNull]
        public uint Id { get; set; }
        public string Type { get; set; }
        public string LegalName { get; set; }
        public string LegalAddress { get; set; }
        public int TRN { get; set; }
        public int BIK { get; set; }
        public uint CreditIds { get; set; }
        public uint ClientIds { get; set; }
    }
}
