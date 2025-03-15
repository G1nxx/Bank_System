using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Domain.Dtos;
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
        private readonly IMapper _mapper;
        private readonly ITransactionHandler _transactionHandler;
        private readonly ITransferHandler _transferHandler;
        private readonly IBankHandler _bankHandler;
        private readonly IUserHandler _userHandler;
        private readonly IRCBAHandler _rcbaHandler;
        private readonly IBAHandler _baHandler;

        public SQLiteUnitOfWork(AppDbContext context,
            IMapper      mapper,
            ITransactionHandler transactionHandler,
            ITransferHandler transferHandler,
            IBankHandler bankHandler,
            IUserHandler userHandler,
            IRCBAHandler rcbaHandler,
            IBAHandler baHandler)
        {
            _context     = context;
            _mapper      = mapper;
            _transactionHandler = transactionHandler;
            _transferHandler = transferHandler;
            _bankHandler = bankHandler;
            _userHandler = userHandler;
            _rcbaHandler = rcbaHandler;
            _baHandler   = baHandler;
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

        public IRCBAHandler GetRCBAHandler(CancellationToken cancellationToken = default)
        {
            return _rcbaHandler;
        }
        
        public IMapper GetMapper(CancellationToken cancellationToken = default)
        {
            return _mapper;
        }

        public IBAHandler GetBAHandler(CancellationToken cancellationToken = default)
        {
            return _baHandler;
        }

        public ITransactionHandler GetTransactionHandler(CancellationToken cancellationToken = default)
        {
            return _transactionHandler;
        }

        public ITransferHandler GetTransferHandler(CancellationToken cancellationToken = default)
        {
            return _transferHandler;
        }
    }
}
