using Domain.Dtos;
using Domain.Dtos.BankDtos.BADtos;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepository<TransactionDto>
    {
        Task<IEnumerable<TransactionDto>> GetTransactionsByType(TransactionType type, CancellationToken cancellationToken);
    }
}
