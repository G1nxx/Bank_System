using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Dtos.BankDtos;
using Application.Interfaces.Handlers;
using AutoMapper;

namespace Infrastructure.Persistence.Handlers
{
    public class BankHandler(
        IBankRepository bankRepository, IMapper bankMapper) : IBankHandler
    {
        public async Task<uint> CreateBankAsync(Bank bank, CancellationToken cancellationToken)
        {
            return await bankRepository.AddAsync(bankMapper.Map<BankDto>(bank), cancellationToken);
        }

        public async Task<Bank> GetBankByIdAsync(uint bankId, CancellationToken cancellationToken)
        {
            return bankMapper.Map<Bank>(await bankRepository.GetByIdAsync(bankId, cancellationToken));
        }

        public async Task<Bank> GetBankByNameAsync(string bankName, CancellationToken cancellationToken)
        {
            return bankMapper.Map<Bank>(await bankRepository.GetBankByNameAsync(bankName, cancellationToken));
        }

        public async Task<IEnumerable<Bank>> GetBanksInfoAsync(CancellationToken cancellationToken)
        {
            return (await bankRepository.GetAllAsync(cancellationToken)).Select(bankMapper.Map<Bank>).ToList();
        }

        public async Task UpdateBank(Bank bank, CancellationToken cancellationToken)
        {
            await bankRepository.UpdateAsync(bankMapper.Map<BankDto>(bank), cancellationToken);
        }

        public async Task DeleteBank(Bank bank, CancellationToken cancellationToken)
        {
            await bankRepository.DeleteAsync(bank.Id, cancellationToken);
        }
    }
} // Entity Farmework
