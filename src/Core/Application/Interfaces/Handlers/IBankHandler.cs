using Domain.Entities;

namespace Application.Interfaces.Handlers
{
    public interface IBankHandler
    {
        Task<uint> CreateBankAsync(Bank bank, CancellationToken cancellationToken);
        Task<Bank> GetBankByIdAsync(uint bankId, CancellationToken cancellationToken);
        Task<Bank> GetBankByNameAsync(string bankName, CancellationToken cancellationToken);
        Task<IEnumerable<Bank>> GetBanksInfoAsync(CancellationToken cancellationToken);
        Task UpdateBank(Bank bank, CancellationToken cancellationToken);
        Task DeleteBank(Bank bank, CancellationToken cancellationToken);
    }
}
