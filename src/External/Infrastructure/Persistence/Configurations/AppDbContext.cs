using Domain.Abstractions;
using Application.Dtos;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{

    public class AppDbContext
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDbContext(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        public async Task CreateTablesAsync()
        {
            await _db.CreateTablesAsync<BankDto, UserDto>();
        }

        public SQLiteAsyncConnection Connection => _db;
    }

}
