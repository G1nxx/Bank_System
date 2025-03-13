using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Handlers
{
    public interface IUserHandler
    {
        Task<uint> CreateUserAsync(User user, CancellationToken cancellationToken);
        Task<User> GetUserByIdAsync(uint userId, CancellationToken cancellationToken);
        Task<User> GetUserByLoginAsync(string userLogin, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken);
        Task UpdateUser(User user, CancellationToken cancellationToken);
        Task DeleteUser(User user, CancellationToken cancellationToken);
    }
}
