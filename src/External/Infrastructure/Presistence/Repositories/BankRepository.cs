using Application.Dtos;
using Application.Interfaces;
using SQLite;

namespace Infrastructure.Presistence.Repositories
{
    public class BankRepository : IRepository<BankDto>
    {
        public SQLiteAsyncConnection database;
        public BankRepository(SQLiteAsyncConnection database)
        {
            this.database = database;
        }
        public async Task<uint> AddAsync(BankDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var s = await database.InsertAsync(entity);
            return (uint)s;
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
