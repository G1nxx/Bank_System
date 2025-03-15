using Domain.Dtos.BankDtos;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using SQLite;

namespace Infrastructure.Persistence.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly AppDbContext _context;
        public BankRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<uint> AddAsync(BankDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.InsertAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankDto>()
                            .Where(t => t.Id == id).DeleteAsync();
        }

        public async Task<IEnumerable<BankDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankDto>().ToListAsync();

            return result;
        }

        public async Task<BankDto> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankDto>()
                            .Where(t => t.Id == id).FirstOrDefaultAsync();
            return result;
        }


        public async Task<BankDto> GetBankByNameAsync(string bankName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<BankDto>()
                            .Where(t => t.LegalName == bankName).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateAsync(BankDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.UpdateAsync(entity);
        }
    }
}
