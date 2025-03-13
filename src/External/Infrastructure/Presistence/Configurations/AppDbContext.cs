using Domain.Abstractions;
using Application.Dtos;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Presistence.Context
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
            await _db.CreateTableAsync<BankDto>();
        }

        public SQLiteAsyncConnection Connection => _db;
    }

}
