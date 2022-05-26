using Microsoft.EntityFrameworkCore;
using RentRide.Data.Core;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories
{
    public class SalonRepository : Repository<Salon>, ISalonRepository
    {

        public SalonRepository(RentRideDbContext context) : base(context)
        {
        }

        public async Task<Salon> GetByIdAsync(Guid id)
        {
            var salon = await GetSalonsQuery()
                .FirstOrDefaultAsync(salon => salon.Id == id);

            return salon;
        }

        public async Task<Salon> GetByLocationAsync(string location)
        {
            var salon = await GetSalonsQuery()
                .FirstOrDefaultAsync(salon => salon.Location == location);

            return salon;
        }

        public async Task<Salon> GetByNameAsync(string name)
        {
            var salon = await GetSalonsQuery()
                .FirstOrDefaultAsync(salon => salon.Name == name);

            return salon;
        }

        private IQueryable<Salon> GetSalonsQuery()
        {
            return Data
                .Include(salon => salon.Cars)
                .Include(salon => salon.Contracts);
        }
    }
}
