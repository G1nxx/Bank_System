using Application.Interfaces.Repositories;
using Domain.Dtos;
using Domain.Dtos.BankDtos;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly AppDbContext _context;
        public TransferRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<uint> AddAsync(TransferDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.InsertAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransferDto>()
                            .Where(t => t.Id == id).DeleteAsync();
        }

        public async Task<IEnumerable<TransferDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransferDto>().ToListAsync();

            return result;
        }

        public async  Task<TransferDto> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransferDto>()
                            .Where(t => t.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<TransferDto> GetTransfersByReceiverId(uint receiverId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransferDto>()
                            .Where(t => t.ReceiverBankAccountId == receiverId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<TransferDto> GetTransfersByRecipientId(uint recipientId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<TransferDto>()
                            .Where(t => t.RecipientBankAccountId == recipientId).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateAsync(TransferDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.UpdateAsync(entity);
        }
    }
}