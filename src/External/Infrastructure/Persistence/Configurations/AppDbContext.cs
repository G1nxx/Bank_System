using Domain.Abstractions;
using Domain.Dtos;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Domain.Dtos.BankDtos.BADtos;
using Domain.Dtos.BankDtos;

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
            Task.Run(async () => await _db.CreateTablesAsync<BankDto,
                                        UserDto,
                                        RCBADto,
                                        BankAccountDto,
                                        TransactionDto>()).Wait();
            await _db.CreateTableAsync<TransferDto>();
        }

        public SQLiteAsyncConnection Connection => _db;
    }

}
