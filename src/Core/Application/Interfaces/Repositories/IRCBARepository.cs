using Domain.Dtos.BankDtos.BADtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRCBARepository : IRepository<RCBADto>
    {
        Task<IEnumerable<RCBADto>> GetRCBAsByUserIdAsync(uint userId, CancellationToken cancellationToken);
        Task<IEnumerable<RCBADto>> GetRCBAsByBankIdAsync(uint bankId, CancellationToken cancellationToken);
        Task<IEnumerable<RCBADto>> GetRCBAsBeforeDate(DateTime date, CancellationToken cancellationToken);
        Task<IEnumerable<RCBADto>> GetRCBAsAfterDate(DateTime date, CancellationToken cancellationToken);
    }
}
