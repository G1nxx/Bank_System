using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    [Table("Banks")]
    internal class BankDto : CompanyDto
    {
        public IEnumerable<uint> CreditIds { get; set; }
        public IEnumerable<uint> ClientIds { get; set; }
    }
}
