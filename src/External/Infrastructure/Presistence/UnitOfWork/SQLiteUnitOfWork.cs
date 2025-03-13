using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.Maui.ApplicationModel;
using SQLite;
using Infrastructure.Presistence.Context;
using Application.Interfaces.Handlers;
using AutoMapper;

namespace Infrastructure.Presistence.UnitOfWork
{
    public class SQLiteUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBankHandler _bankHandler;

        public SQLiteUnitOfWork(AppDbContext context, IMapper mapper, IBankHandler bankHandler)
        {
            _context = context;
            _mapper = mapper;
            _bankHandler = bankHandler;
            Task.Run(async () =>
            {
                await _context.CreateTablesAsync();
            }).Wait();

        }

        public async Task SaveAllAsync(CancellationToken cancellationToken = default)
        {
            var banks = await _bankHandler.GetBanksInfoAsync(cancellationToken);
            await _context.Connection.UpdateAllAsync(banks);
        }

        public IBankHandler GetBankHandler(CancellationToken cancellationToken = default)
        {
            return _bankHandler;
        }
    }
}
