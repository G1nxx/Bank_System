using Application.Dtos;
using Application.Interfaces.Repositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence.Repositories
{
    internal class UserRepository(SQLiteAsyncConnection database) : IUserRepository
    {
        public async Task<uint> AddAsync(UserDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            uint s = (uint)await database.InsertAsync(entity);
            return s;
        }

        public async Task DeleteAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await database.Table<UserDto>()
                            .Where(t => t.Id == id).DeleteAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await database.Table<UserDto>().ToListAsync();
            return result;
        }

        public async Task<UserDto> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await database.Table<UserDto>()
                            .Where(t => t.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<UserDto> GetByLoginAsync(string Login, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await database.Table<UserDto>()
                            .Where(t => t.Login == Login).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateAsync(UserDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await database.UpdateAsync(entity);
        }
    }
}
