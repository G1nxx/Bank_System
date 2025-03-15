using Application.Interfaces.Handlers;
using Application.Interfaces.Repositories;
using Domain.Dtos.BankDtos;
using Domain.Entities;
using Domain.Entities.Transactions;
using Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using Domain.Dtos;

namespace Infrastructure.Persistence.Handlers
{
    public class TransactionHandler(
        ITransactionRepository transactionRepository, IMapper transactionMapper) : ITransactionHandler
    {
        public async Task<uint> CreateTransactionAsync(Transaction transaction, CancellationToken cancellationToken)
        {
            return await transactionRepository.AddAsync(transactionMapper.Map<TransactionDto>(transaction), cancellationToken);
        }

        public async Task DeleteTransaction(Transaction transaction, CancellationToken cancellationToken)
        {
            await transactionRepository.DeleteAsync(transaction.Id, cancellationToken);
        }

        public async Task<Transaction> GetTransactionByIdAsync(uint transactionId, CancellationToken cancellationToken)
        {
            return transactionMapper.Map<Transaction>(await transactionRepository.GetByIdAsync(transactionId, cancellationToken));
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(CancellationToken cancellationToken)
        {
            return (await transactionRepository.GetAllAsync(cancellationToken)).Select(transactionMapper.Map<Transaction>).ToList();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(TransactionType type, CancellationToken cancellationToken)
        {
            return (await transactionRepository.GetTransactionsByType(type, cancellationToken)).Select(transactionMapper.Map<Transaction>).ToList();
        }

        public async Task UpdateTransaction(Transaction transaction, CancellationToken cancellationToken)
        {
            await transactionRepository.UpdateAsync(transactionMapper.Map<TransactionDto>(transaction), cancellationToken);
        }
    }
}