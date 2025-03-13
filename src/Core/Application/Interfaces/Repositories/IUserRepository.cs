using Application.Dtos;
using System.Security.Cryptography.X509Certificates;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserDto>
    {
        /*
        Task<uint> AddAsync(T entity, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(uint id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(uint id, CancellationToken cancellationToken);
         */

        Task<UserDto> GetByLoginAsync(string Login, CancellationToken cancellationToken);
    }
}
