using RentRide.Data.Contracts;
using RentRide.DomainModels;
using System;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories.Abstracts
{
    public interface ISalonRepository : IRepository<Salon>
    {
        Task<Salon> GetByIdAsync(Guid id);

        Task<Salon> GetByNameAsync(string name);

        Task<Salon> GetByLocationAsync(string location);
  
    }
}
