using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentRide.Data.Contracts;
using RentRide.DomainModels;

namespace RentRide.Data.Repositories.Abstracts
{
    public interface ICarModelRepository : IRepository<CarModel>
    {
        Task<CarModel> GetByIdAsync(Guid id);

        IEnumerable<CarModel> GetByModel(string model);

        bool FindAsync(CarModel carModel);
    }
}