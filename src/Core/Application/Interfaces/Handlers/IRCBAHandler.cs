using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Handlers
{
    public interface IRCBAHandler
    {
        Task<uint> CreateRCBAAsync(RCBA rcba, CancellationToken cancellationToken);
        Task<RCBA> GetRCBAByIdAsync(uint rcbaId, CancellationToken cancellationToken);
        Task<IEnumerable<RCBA>> GetRCBAsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<RCBA>> GetRCBAsByUserIdAsync(uint userId, CancellationToken cancellationToken);
        Task<IEnumerable<RCBA>> GetRCBAsByBankIdAsync(uint bankId, CancellationToken cancellationToken);
        Task<IEnumerable<RCBA>> GetRCBAsAfterDate(DateTime date, CancellationToken cancellationToken);
        Task<IEnumerable<RCBA>> GetRCBAsBeforeDate(DateTime date, CancellationToken cancellationToken);
        Task UpdateRCBA(RCBA rcba, CancellationToken cancellationToken);
        Task DeleteRCBA(RCBA rcba, CancellationToken cancellationToken);
    }
}
