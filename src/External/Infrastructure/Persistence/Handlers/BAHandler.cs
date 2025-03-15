using Application.Interfaces.Handlers;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Dtos.BankDtos.BADtos;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Handlers
{
    public class BAHandler(
        IBARepository requestRepository, IMapper requestMapper) : IBAHandler
    {

        public async Task<uint> CreateBAAsync(BankAccount request, CancellationToken cancellationToken)
        {
            return await requestRepository.AddAsync(requestMapper.Map<BankAccountDto>(request), cancellationToken);
        }

        public async Task DeleteBA(BankAccount request, CancellationToken cancellationToken)
        {
            await requestRepository.DeleteAsync(request.Id, cancellationToken);
        }

        public async Task<BankAccount> GetBAByIdAsync(uint requestId, CancellationToken cancellationToken)
        {
            return requestMapper.Map<BankAccount>(await requestRepository.GetByIdAsync(requestId, cancellationToken));
        }
        public async Task<BankAccount> GetBAByAccountNumberAsync(string bankNumber, CancellationToken cancellationToken)
        {
            return requestMapper.Map<BankAccount>(await requestRepository.GetBAByAccountNumberAsync(bankNumber, cancellationToken));
        }

        public async Task<IEnumerable<BankAccount>> GetBAsAsync(CancellationToken cancellationToken)
        {
            return (await requestRepository.GetAllAsync(cancellationToken)).Select(requestMapper.Map<BankAccount>).ToList();
        }

        public async Task<IEnumerable<BankAccount>> GetBAsBeforeDate(DateTime date, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetBAsBeforeDate(date, cancellationToken)).Select(requestMapper.Map<BankAccount>).ToList();
        }

        public async Task<IEnumerable<BankAccount>> GetBAsAfterDate(DateTime date, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetBAsAfterDate(date, cancellationToken)).Select(requestMapper.Map<BankAccount>).ToList();
        }

        public async Task<IEnumerable<BankAccount>> GetBAsByBankIdAsync(uint bankId, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetBAsByBankIdAsync(bankId, cancellationToken)).Select(requestMapper.Map<BankAccount>).ToList();
        }

        public async Task<IEnumerable<BankAccount>> GetBAsByUserIdAsync(uint userId, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetBAsByUserIdAsync(userId, cancellationToken)).Select(requestMapper.Map<BankAccount>).ToList();
        }

        public async Task UpdateBA(BankAccount request, CancellationToken cancellationToken)
        {
            await requestRepository.UpdateAsync(requestMapper.Map<BankAccountDto>(request), cancellationToken);
        }

        public async Task<IEnumerable<BankAccount>> GetBAsByCurrency(CurrencyType type, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetBAsByCurrency(type, cancellationToken)).Select(requestMapper.Map<BankAccount>).ToList();
        }
    }
}
