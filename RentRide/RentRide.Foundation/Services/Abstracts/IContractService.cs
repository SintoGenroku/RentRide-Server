using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentRide.DomainModels;

namespace RentRide.Foundation.Services.Abstracts
{
    public interface IContractService
    {
        Task<IReadOnlyCollection<Contract>> GetContractsAsync();

        Task<Contract> GetContractById(Guid id);

        Task CreateContractAsync(Contract contract);
        
        Task UpdateContractAsync(Contract contract);
        
        Task DeleteContractAsync(Contract contract);

    }
}