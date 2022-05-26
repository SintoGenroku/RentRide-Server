using RentRide.Data.Contracts;
using RentRide.DomainModels;
using System;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories.Abstracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(Guid id);

        Task<User> GetByNameAsync(string name);
    }
}
