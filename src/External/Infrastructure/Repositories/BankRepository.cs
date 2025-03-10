using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using SQLite;

namespace Infrastructure.Repositories
{
    internal class BankRepository(SQLiteAsyncConnection database) : IRepository<BankDto>
    {
        public async Task<uint> AddAsync(BankDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            uint s = (uint)await database.InsertAsync(entity);
            return s;
        }

        public async Task DeleteAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await database.Table<BankDto>()
                            .Where(t => t.Id == id).DeleteAsync();
        }

        public async Task<IEnumerable<BankDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await database.Table<BankDto>().ToListAsync();

            return result;
        }

        public async Task<BankDto> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await database.Table<BankDto>()
                            .Where(t => t.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateAsync(BankDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await database.UpdateAsync(entity);
        }        
    }
}
