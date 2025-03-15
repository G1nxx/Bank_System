using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Handlers
{
    public interface IBAHandler
    {
        Task<uint> CreateBAAsync(BankAccount ba, CancellationToken cancellationToken);
        Task<BankAccount> GetBAByIdAsync(uint baId, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccount>> GetBAsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<BankAccount>> GetBAsByCurrency(CurrencyType type, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccount>> GetBAsByUserIdAsync(uint userId, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccount>> GetBAsByBankIdAsync(uint bankId, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccount>> GetBAsAfterDate(DateTime date, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccount>> GetBAsBeforeDate(DateTime date, CancellationToken cancellationToken);
        Task UpdateBA(BankAccount ba, CancellationToken cancellationToken);
        Task DeleteBA(BankAccount ba, CancellationToken cancellationToken);
    }
}
