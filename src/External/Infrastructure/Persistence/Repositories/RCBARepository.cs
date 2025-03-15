using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Dtos.BankDtos.BADtos;

namespace Infrastructure.Persistence.Repositories
{
    public class RCBARepository : IRCBARepository
    {

        private readonly AppDbContext _context;
        public RCBARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<uint> AddAsync(RCBADto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.InsertAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<RCBADto>()
                            .Where(t => t.Id == id).DeleteAsync();
        }

        public async Task<IEnumerable<RCBADto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<RCBADto>().ToListAsync();

            return result;
        }

        public async Task<IEnumerable<RCBADto>> GetRCBAsAfterDate(DateTime date, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<RCBADto>()
                            .Where(t => t.CreatedAt > date).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<RCBADto>> GetRCBAsBeforeDate(DateTime date, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<RCBADto>()
                            .Where(t => t.CreatedAt < date).ToListAsync();
            return result;
        }

        public async Task<RCBADto> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<RCBADto>()
                            .Where(t => t.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<RCBADto>> GetRCBAsByBankIdAsync(uint bankId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<RCBADto>()
                            .Where(t => t.BankId == bankId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<RCBADto>> GetRCBAsByUserIdAsync(uint userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _context.Connection.Table<RCBADto>()
                            .Where(t => t.UserId == userId).ToListAsync();
            return result;
        }

        public async Task UpdateAsync(RCBADto entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.UpdateAsync(entity);
        }
    }
}
