using Domain.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.BankDtos
{
    [Table("Banks")]
    public class BankDto : CompanyDto
    {
        public int TRN { get; set; }
        public int BIK { get; set; }
    }
}
