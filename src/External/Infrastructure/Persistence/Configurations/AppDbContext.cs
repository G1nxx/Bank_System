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
            await _db.CreateTablesAsync<BankDto, 
                                        UserDto, 
                                        RCBADto, 
                                        BankAccountDto,
                                        TransactionDto>();
        }

        public SQLiteAsyncConnection Connection => _db;
    }

}
