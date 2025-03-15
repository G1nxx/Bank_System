using Domain.Dtos.BankDtos;
using Domain.Dtos.BankDtos.BADtos;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IBARepository : IRepository<BankAccountDto>
    {
        Task<IEnumerable<BankAccountDto>> GetBAsByUserIdAsync(uint userId, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccountDto>> GetBAsByBankIdAsync(uint bankId, CancellationToken cancellationToken);
        Task<BankAccountDto> GetBAByAccountNumberAsync(string AccountNumber, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccountDto>> GetBAsBeforeDate(DateTime date, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccountDto>> GetBAsAfterDate(DateTime date, CancellationToken cancellationToken);
        Task<IEnumerable<BankAccountDto>> GetBAsByCurrency(CurrencyType type, CancellationToken cancellationToken);
    }
}
