using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Bank
    {
        public uint Id { get; set; }
        public CompanyType Type { get; set; }
        public string LegalName { get; set; }
        public string LegalAddress { get; set; }
        public int TRN { get; set; }
        public int BIK { get; set; }
        public uint CreditIds { get; set; }
        public uint ClientIds { get; set; }
    }
}
