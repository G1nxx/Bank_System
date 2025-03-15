using Domain.Entities;
using Domain.Entities.Transactions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Handlers
{
    public interface ITransactionHandler
    {
        Task<uint> CreateTransactionAsync(Transaction transaction, CancellationToken cancellationToken);
        Task<Transaction> GetTransactionByIdAsync(uint transactionId, CancellationToken cancellationToken);
        Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(TransactionType type, CancellationToken cancellationToken);
        Task<IEnumerable<Transaction>> GetTransactionsAsync(CancellationToken cancellationToken);
        Task UpdateTransaction(Transaction transaction, CancellationToken cancellationToken);
        Task DeleteTransaction(Transaction transaction, CancellationToken cancellationToken);
    }
}
