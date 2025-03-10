using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstractions
{
    internal class BankAccount
    {
        string AccountID { get; }
        string TransferID { get; }
        //Client Client { get; }
        decimal Value { get; }
    }
}
