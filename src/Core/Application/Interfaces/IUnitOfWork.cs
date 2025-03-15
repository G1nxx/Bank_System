using Application.Interfaces.Handlers;
using AutoMapper;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    public Task SaveAllAsync(CancellationToken cancellationToken = default);
    public IBankHandler GetBankHandler(CancellationToken cancellationToken = default);
    public IUserHandler GetUserHandler(CancellationToken cancellationToken = default);
    public IRCBAHandler GetRCBAHandler(CancellationToken cancellationToken = default);
    public IBAHandler GetBAHandler(CancellationToken cancellationToken = default);
    public ITransactionHandler GetTransactionHandler(CancellationToken cancellationToken = default);
    public ITransferHandler GetTransferHandler(CancellationToken cancellationToken = default);
    public IMapper GetMapper(CancellationToken cancellationToken = default);
}
