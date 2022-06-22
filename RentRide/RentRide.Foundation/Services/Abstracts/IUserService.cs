using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentRide.DomainModels;

namespace RentRide.Foundation.Services.Abstracts
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<User>> GetUsersAsync();

        Task DeleteUsersAsync(User user);

        Task<User> GetUserByIdAsync(Guid id);

        Task UpdateAsync(User user);
    }
}