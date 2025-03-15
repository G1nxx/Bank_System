using Domain.Dtos.BankDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IBankRepository : IRepository<BankDto>
    {
        public Task<BankDto> GetBankByNameAsync(string bankName, CancellationToken cancellationToken);
    }
}
