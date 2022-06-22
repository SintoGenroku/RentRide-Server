using Microsoft.EntityFrameworkCore;
using RentRide.Data.Core;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;
using System;
using System.Collections.Generic;
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

        public  IEnumerable<Salon> GetByLocation(string location)
        {
            var salon = GetSalonsQuery()
                .Where(salon => salon.Location == location);

            return salon;
        }

        public IEnumerable<Salon> GetByName(string name)
        {
            var salon =  GetSalonsQuery()
                .Where(salon => salon.Name == name);

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
