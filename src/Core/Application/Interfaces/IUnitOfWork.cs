using Domain.Entities;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    public Task SaveAllAsync(CancellationToken cancellationToken = default);
    public Task DeleteDataBaseAsync(CancellationToken cancellationToken = default);
    public Task CreateDataBaseAsync(CancellationToken cancellationToken = default);
    public Task<IEnumerable<Bank>> GetAllBanksAsync(CancellationToken cancellationToken = default);
}
