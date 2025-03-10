using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Entities
{
    internal class Bank
    {
        string LegalName { get; }
        string LegalAddress { get; }
        IEnumerable<BankAccount> Credits { get; }
        IEnumerable<IUser> Clients { get; }
    }
}
