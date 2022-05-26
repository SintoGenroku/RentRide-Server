using RentRide.Data.Contracts;
using RentRide.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories.Abstracts
{
    public interface IContractRepository : IRepository<Contract>
    {
        Task<Contract> GetByIdAsync(Guid id);

        IEnumerable<Contract> GetBySalonId(Guid id);

        IEnumerable<Contract> GetByClientId(Guid id);


        IEnumerable<Contract> GetByDateAsync(DateTime? Date); 
    }
}
