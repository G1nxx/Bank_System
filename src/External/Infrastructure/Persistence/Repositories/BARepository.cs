using Application.Interfaces.Repositories;
using Domain.Dtos.BankDtos;
using Domain.Dtos.BankDtos.BADtos;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class BARepository : IBARepository
    {
        private readonly AppDbContext _context;
        public BARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<uint> AddAsync(BankAccountDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.InsertAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>()
                            .Where(t => t.Id == id).DeleteAsync();
        }

        public async Task<IEnumerable<BankAccountDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>().ToListAsync();
            return result;
        }

        public async Task<BankAccountDto> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>()
                            .Where(t => t.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<BankAccountDto>> GetBAsByBankIdAsync(uint bankId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>()
                            .Where(t => t.BankId == bankId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BankAccountDto>> GetBAsByUserIdAsync(uint userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>()
                            .Where(t => t.UserId == userId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BankAccountDto>> GetBAsAfterDate(DateTime date, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>()
                            .Where(t => t.CreatedAt > date).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BankAccountDto>> GetBAsBeforeDate(DateTime date, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>()
                            .Where(t => t.CreatedAt < date).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BankAccountDto>> GetBAsByCurrency(CurrencyType type, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>()
                            .Where(t => t.Currency == Enum.GetName(typeof(CurrencyType),type)).ToListAsync();
            return result;
        }

        public async Task UpdateAsync(BankAccountDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.UpdateAsync(entity);
        }

        public async Task<BankAccountDto> GetBAByAccountNumberAsync(string accountNumber, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankAccountDto>()
                            .Where(t => t.AccountNumber == accountNumber).FirstOrDefaultAsync();
            return result;
        }
    }
}

