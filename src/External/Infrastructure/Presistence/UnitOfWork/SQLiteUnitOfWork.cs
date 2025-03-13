using Domain.Abstractions;
using Domain.Entities;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.Maui.ApplicationModel;
using SQLite;
using Infrastructure.Presistence.Context;
using Infrastructure.Presistence.Repositories;
using AutoMapper;

namespace Infrastructure.Presistence.UnitOfWork
{
    public class SQLiteUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly BankRepository _bankRepository;

        public SQLiteUnitOfWork(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _bankRepository = new(_context.Connection);
            Task.Run(async () =>
            {
                await _context.CreateTablesAsync();
                await Init();
            }).Wait();

        }
        private async Task Init()
        {
            await _bankRepository.AddAsync(new BankDto
            {
                Id = 1,
                Type = "OAO",
                BIK = 10201010,
                TRN = 32124344,
                LegalAddress = "Syvorova 12",
                LegalName = "Bank-Propan",
                ClientIds = 1134,
                CreditIds = 1123
            }, new CancellationToken());
        }
        public async Task CreateDataBaseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.CreateTablesAsync<EntityDto, CompanyDto, BankDto>();
        }

        public async Task DeleteDataBaseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Connection.DeleteAllAsync<EntityDto>();
            await _context.Connection.DeleteAllAsync<CompanyDto>();
            await _context.Connection.DeleteAllAsync<BankDto>();
        }

        public async Task SaveAllAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var banks = await _bankRepository.GetAllAsync(cancellationToken);
            await _context.Connection.UpdateAllAsync(banks);
        }

        public async Task<IEnumerable<Bank>> GetAllBanksAsync(CancellationToken cancellationToken = default)
        {
            var bankDtos = await _bankRepository.GetAllAsync(cancellationToken);
            var result = new List<Bank>();

            foreach (var bank in bankDtos)
            {
                result.Add(_mapper.Map<Bank>(bank));
            }

            return result;
        }
    }
}
