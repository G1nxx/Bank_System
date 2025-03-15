using Domain.Dtos;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<uint> AddAsync(UserDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.InsertAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<UserDto>()
                            .Where(t => t.Id == id).DeleteAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<UserDto>().ToListAsync();
            return result;
        }

        public async Task<UserDto> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<UserDto>()
                            .Where(t => t.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<UserDto> GetByLoginAsync(string Login, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<UserDto>()
                            .Where(t => t.Login == Login).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateAsync(UserDto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.UpdateAsync(entity);
        }
    }
}
