using RentRide.Data.Contracts;
using RentRide.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories.Abstracts
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> GetByIdAsync(Guid id);

        IEnumerable<Car> GetBySalonId(Guid id);

        IEnumerable<Car> GetByBrand(string brand);

    }
}
