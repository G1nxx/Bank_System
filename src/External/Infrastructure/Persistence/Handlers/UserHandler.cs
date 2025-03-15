using Domain.Dtos;
using Application.Interfaces.Handlers;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Handlers
{
    public class UserHandler(
        IUserRepository userRepository, IMapper userMapper) : IUserHandler
    {
        public async Task<uint> CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            return await userRepository.AddAsync(userMapper.Map<UserDto>(user), cancellationToken);
        }

        public async Task DeleteUser(User user, CancellationToken cancellationToken)
        {
            await userRepository.DeleteAsync(user.Id, cancellationToken);
        }

        public async Task<User> GetUserByIdAsync(uint userId, CancellationToken cancellationToken)
        {
            return userMapper.Map<User>(await userRepository.GetByIdAsync(userId, cancellationToken));
        }

        public async Task<User> GetUserByLoginAsync(string userLogin, CancellationToken cancellationToken)
        {
            return userMapper.Map<User>(await userRepository.GetByLoginAsync(userLogin, cancellationToken));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return (await userRepository.GetAllAsync(cancellationToken)).Select(userMapper.Map<User>).ToList();
        }

        public async Task UpdateUser(User user, CancellationToken cancellationToken)
        {
            await userRepository.UpdateAsync(userMapper.Map<UserDto>(user), cancellationToken);
        }
    }
}