using Application.Interfaces.Repositories;
using Domain.Dtos;
using Domain.Dtos.BankDtos;
using Domain.Enums;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<uint> AddAsync(TransactionDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.InsertAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransactionDto>()
                            .Where(t => t.Id == id).DeleteAsync();
        }

        public async Task<IEnumerable<TransactionDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransactionDto>().ToListAsync();

            return result;
        }

        public async Task<TransactionDto> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransactionDto>()
                            .Where(t => t.Id== id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByType(TransactionType type, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransactionDto>()
                            .Where(t => t.Type == Enum.GetName(typeof(TransactionType),type)).ToListAsync();
            return result;
        }

        public async Task UpdateAsync(TransactionDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.UpdateAsync(entity);
        }
    }
}