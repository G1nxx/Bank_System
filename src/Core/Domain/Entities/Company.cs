using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public enum CompanyType
    {
        None,
        IP,
        OOO,
        OAO,
        ODO,
        ZAO
    }

    internal interface ICompany
    {
        public CompanyType Type { get; }
        string LegalName { get; }
        int TRN { get; }
        int BIK { get; }
        string LegalAddress { get; }

    }
}
