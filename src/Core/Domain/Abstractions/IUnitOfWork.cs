namespace Domain.Abstractions
{
    public interface IUnitOfWork
    {
        public Task SaveAllAsync(CancellationToken cancellationToken = default);
        public Task DeleteDataBaseAsync(CancellationToken cancellationToken = default);
        public Task CreateDataBaseAsync(CancellationToken cancellationToken = default);
    }
}
