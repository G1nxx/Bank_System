using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Handlers
{
    public interface ITransferHandler
    {
        Task<uint> CreateTransferAsync(Transfer transfer, CancellationToken cancellationToken);
        Task<Transfer> GetTransferByIdAsync(uint transferId, CancellationToken cancellationToken);
        Task<Transfer> GetTransferByRecipientId(uint recipientId, CancellationToken cancellationToken);
        Task<Transfer> GetTransferByReceiverId(uint receiverId, CancellationToken cancellationToken);
        Task<IEnumerable<Transfer>> GetTransfersAsync(CancellationToken cancellationToken);
        Task UpdateTransfer(Transfer transfer, CancellationToken cancellationToken);
        Task DeleteTransfer(Transfer transfer, CancellationToken cancellationToken);
    }
}

