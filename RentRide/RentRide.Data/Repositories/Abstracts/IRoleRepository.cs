using RentRide.Data.Contracts;
using RentRide.DomainModels;
using System;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories.Abstracts
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByIdAsync(Guid id);

        Task<Role> GetByNameAsync(string name);
    }
}
