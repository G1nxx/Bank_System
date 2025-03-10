using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        Task<uint> AddAsync(T entity, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(uint id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(uint id, CancellationToken cancellationToken);
    }
}
