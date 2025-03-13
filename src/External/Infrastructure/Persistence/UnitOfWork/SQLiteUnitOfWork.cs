using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.Maui.ApplicationModel;
using SQLite;
using Infrastructure.Persistence.Context;
using Application.Interfaces.Handlers;
using AutoMapper;

namespace Infrastructure.Persistence.UnitOfWork
{
    public class SQLiteUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IBankHandler _bankHandler;
        private readonly IUserHandler _userHandler;

        public SQLiteUnitOfWork(AppDbContext context, IBankHandler bankHandler, IUserHandler userHandler)
        {
            _context = context;
            _bankHandler = bankHandler;
            _userHandler = userHandler;
            Task.Run(async () =>
            {
                await _context.CreateTablesAsync();
            }).Wait();
            _userHandler = userHandler;
        }

        public async Task SaveAllAsync(CancellationToken cancellationToken = default)
        {
            var banks = await _bankHandler.GetBanksInfoAsync(cancellationToken);
            await _context.Connection.UpdateAllAsync(banks);
            var users = await _userHandler.GetUsersAsync(cancellationToken);
            await _context.Connection.UpdateAllAsync(users);
        }

        public IBankHandler GetBankHandler(CancellationToken cancellationToken = default)
        {
            return _bankHandler;
        }

        public IUserHandler GetUserHandler(CancellationToken cancellationToken = default)
        {
            return _userHandler;
        }
    }
}
