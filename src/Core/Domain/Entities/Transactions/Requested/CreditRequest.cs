﻿using Domain.Abstractions;

namespace Domain.Entities.Transactions.Requested
{
    internal class CreditRequest : IRequestBankService
    {
        public int TermInMonths { get; private set; }

        public string Message { get; private set; }

        public decimal InterestRate { get; private set; }
    }
}
