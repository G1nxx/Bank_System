﻿using Domain.Entities;

namespace Application.Interfaces.Handlers
{
    public interface IBankHandler
    {
        Task<uint> CreateBank(Bank bank, CancellationToken cancellationToken);
        Task<Bank> GetBankInfoByIdAsync(uint bankId, CancellationToken cancellationToken);
        Task<Bank> GetBankByIdAsync(uint bankId, CancellationToken cancellationToken);
        Task<IEnumerable<Bank>> GetBanksInfoAsync(CancellationToken cancellationToken);
        Task UpdateBank(Bank bank, CancellationToken cancellationToken);
    }
}
