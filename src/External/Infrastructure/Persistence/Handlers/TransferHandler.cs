using Application.Interfaces.Handlers;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.BankDtos;
using Domain.Entities;
using Domain.Entities.Transactions;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Persistence.Handlers
{
    public class TransferHandler(
        ITransferRepository transferRepository, IMapper transferMapper) : ITransferHandler
    {
        public async Task<uint> CreateTransferAsync(Transfer transfer, CancellationToken cancellationToken)
        {
            return await transferRepository.AddAsync(transferMapper.Map<TransferDto>(transfer), cancellationToken);
        }

        public async Task DeleteTransfer(Transfer transfer, CancellationToken cancellationToken)
        {
            await transferRepository.DeleteAsync(transfer.Id, cancellationToken);
        }

        public async Task<Transfer> GetTransferByIdAsync(uint transferId, CancellationToken cancellationToken)
        {
            return transferMapper.Map<Transfer>(await transferRepository.GetByIdAsync(transferId, cancellationToken));
        }

        public async Task<Transfer> GetTransferByReceiverId(uint receiverId, CancellationToken cancellationToken)
        {
            return transferMapper.Map<Transfer>(await transferRepository.GetTransfersByReceiverId(receiverId, cancellationToken));
        }

        public async Task<Transfer> GetTransferByRecipientId(uint recipientId, CancellationToken cancellationToken)
        {
            return transferMapper.Map<Transfer>(await transferRepository.GetTransfersByRecipientId(recipientId, cancellationToken));
        }

        public async Task<IEnumerable<Transfer>> GetTransfersAsync(CancellationToken cancellationToken)
        {
            return (await transferRepository.GetAllAsync(cancellationToken)).Select(transferMapper.Map<Transfer>).ToList();
        }

        public async Task UpdateTransfer(Transfer transfer, CancellationToken cancellationToken)
        {
            await transferRepository.UpdateAsync(transferMapper.Map<TransferDto>(transfer), cancellationToken);
        }
    }
}