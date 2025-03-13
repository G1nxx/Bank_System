using Application.Interfaces;
using Domain.Entities;
using Application.Dtos;
using Application.Interfaces.Handlers;
using AutoMapper;

namespace Application.Handlers
{
    public class BankHandler(
     IRepository<BankDto> bankRepository, IMapper bankMapper) : IBankHandler
    {
        public async Task<uint> CreateBankAsync(Bank bank, CancellationToken cancellationToken)
        {
            return await bankRepository.AddAsync(bankMapper.Map<BankDto>(bank), cancellationToken);
        }

        public async Task<Bank> GetBankInfoByIdAsync(uint bankId, CancellationToken cancellationToken)
        {
            return bankMapper.Map<Bank>(await bankRepository.GetByIdAsync(bankId, cancellationToken));
        }

        public async Task<Bank> GetBankByIdAsync(uint bankId, CancellationToken cancellationToken)
        {
            return bankMapper.Map<Bank>(await bankRepository.GetByIdAsync(bankId, cancellationToken));
        }

        public async Task<IEnumerable<Bank>> GetBanksInfoAsync(CancellationToken cancellationToken)
        {
            return (await bankRepository.GetAllAsync(cancellationToken)).Select(bankMapper.Map<Bank>).ToList();
        }

        public async Task UpdateBank(Bank bank, CancellationToken cancellationToken)
        {
            await bankRepository.UpdateAsync(bankMapper.Map<BankDto>(bank), cancellationToken);
        }
    }
} // Entity Farmework
