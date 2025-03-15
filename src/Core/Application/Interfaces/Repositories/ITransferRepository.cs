using Domain.Dtos;
using Domain.Dtos.BankDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ITransferRepository : IRepository<TransferDto>
    {
        public Task<TransferDto> GetTransfersByRecipientId(uint recipientId, CancellationToken cancellationToken);
        public Task<TransferDto> GetTransfersByReceiverId(uint receiverId, CancellationToken cancellationToken);
    }
}
