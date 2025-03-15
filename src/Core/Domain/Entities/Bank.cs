using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Bank : Company
    {
        public int TRN { get; set; }
        public int BIK { get; set; }
    }
}
