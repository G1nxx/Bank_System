using Application.Dtos;
using Application.Interfaces;
using Infrastructure.Persistence.Context;
using SQLite;

namespace Infrastructure.Persistence.Repositories
{
    public class BankRepository : IRepository<BankDto>
    {
        private readonly AppDbContext _context;
        public BankRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<uint> AddAsync(BankDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var s = await _context.Connection.InsertAsync(entity);
            return (uint)s;
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

        public async Task UpdateAsync(BankDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.UpdateAsync(entity);
        }
    }
}
