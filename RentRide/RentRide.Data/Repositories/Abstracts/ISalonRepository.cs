using RentRide.Data.Contracts;
using RentRide.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories.Abstracts
{
    public interface ISalonRepository : IRepository<Salon>
    {
        Task<Salon> GetByIdAsync(Guid id);

        IEnumerable<Salon> GetByName(string name);

        IEnumerable<Salon> GetByLocation(string location);
  
    }
}
