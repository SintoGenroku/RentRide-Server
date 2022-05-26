using Microsoft.EntityFrameworkCore;
using RentRide.Data.Core;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RentRideDbContext context) : base(context)
        {
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await GetUserQuery()
                .FirstOrDefaultAsync(user => user.Id == id);

            return user;
        }

        public async Task<User> GetByNameAsync(string name)
        {
            var user = await GetUserQuery()
                .FirstOrDefaultAsync(user => user.UserName == name);

            return user;
        }

        private IQueryable<User> GetUserQuery()
        {
            return Data
                .Include(user => user.Roles)
                .Include(user => user.Contracts);
        }
    }
}
