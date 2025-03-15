using Domain.Dtos.BankDtos.BADtos;
using Application.Interfaces;
using Application.Interfaces.Handlers;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Persistence.Handlers
{
    public class RCBAHandler(
        IRCBARepository requestRepository, IMapper requestMapper) : IRCBAHandler
    {

        public async Task<uint> CreateRCBAAsync(RCBA request, CancellationToken cancellationToken)
        {
            return await requestRepository.AddAsync(requestMapper.Map<RCBADto>(request), cancellationToken);
        }

        public async Task DeleteRCBA(RCBA request, CancellationToken cancellationToken)
        {
            await requestRepository.DeleteAsync(request.Id, cancellationToken);
        }

        public async Task<RCBA> GetRCBAByIdAsync(uint requestId, CancellationToken cancellationToken)
        {
            return requestMapper.Map<RCBA>(await requestRepository.GetByIdAsync(requestId, cancellationToken));
        }

        public async Task<IEnumerable<RCBA>> GetRCBAsAsync(CancellationToken cancellationToken)
        {
            return (await requestRepository.GetAllAsync(cancellationToken)).Select(requestMapper.Map<RCBA>).ToList();
        }

        public async Task<IEnumerable<RCBA>> GetRCBAsBeforeDate(DateTime date, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetRCBAsBeforeDate(date, cancellationToken)).Select(requestMapper.Map<RCBA>).ToList();
        }

        public  async Task<IEnumerable<RCBA>> GetRCBAsAfterDate(DateTime date, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetRCBAsAfterDate(date, cancellationToken)).Select(requestMapper.Map<RCBA>).ToList();
        }

        public async Task<IEnumerable<RCBA>> GetRCBAsByBankIdAsync(uint bankId, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetRCBAsByBankIdAsync(bankId, cancellationToken)).Select(requestMapper.Map<RCBA>).ToList();
        }

        public async Task<IEnumerable<RCBA>> GetRCBAsByUserIdAsync(uint userId, CancellationToken cancellationToken)
        {
            return (await requestRepository.GetRCBAsByBankIdAsync(userId, cancellationToken)).Select(requestMapper.Map<RCBA>).ToList();
        }

        public async Task UpdateRCBA(RCBA request, CancellationToken cancellationToken)
        {
            await requestRepository.UpdateAsync(requestMapper.Map<RCBADto>(request), cancellationToken);
        }
    }
}