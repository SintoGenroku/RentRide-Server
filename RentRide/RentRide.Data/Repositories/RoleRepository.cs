using Microsoft.EntityFrameworkCore;
using RentRide.Data.Core;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;
using System;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            var role = await Data
                .FirstOrDefaultAsync(role => role.Id == id);
            return role;
        }

        public async Task<Role> GetByNameAsync(string name)
        {
            var role = await Data
                .FirstOrDefaultAsync(role => role.Name == name);

            return role;
        }
    }
}
