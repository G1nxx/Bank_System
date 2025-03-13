using Application.Interfaces.Handlers;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    public Task SaveAllAsync(CancellationToken cancellationToken = default);
    public IBankHandler GetBankHandler(CancellationToken cancellationToken = default);
    public IUserHandler GetUserHandler(CancellationToken cancellationToken = default);
}
