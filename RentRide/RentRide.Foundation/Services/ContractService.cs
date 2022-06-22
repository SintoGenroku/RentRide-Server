using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentRide.Data;
using RentRide.DomainModels;
using RentRide.Foundation.Services.Abstracts;

namespace RentRide.Foundation.Services
{
    public class ContractService : IContractService
    {
        private readonly IRentRideUnitOfWork _unitOfWork;

        public ContractService(IRentRideUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Contract>> GetContractsAsync()
        {
            var contracts = await _unitOfWork.Contracts.GetAllAsync();
            
            return contracts;
        }

        public async Task<Contract> GetContractById(Guid id)
        {
            var contract = await _unitOfWork.Contracts.GetByIdAsync(id);

            return contract;
        }

        public async Task CreateContractAsync(Contract contract)
        {
            await _unitOfWork.Contracts.CreateAsync(contract);
        }

        public async Task UpdateContractAsync(Contract contract)
        {
            await _unitOfWork.Contracts.UpdateAsync(contract);
        }

        public async Task DeleteContractAsync(Contract contract)
        {
            await _unitOfWork.Contracts.DeleteAsync(contract);
        }
    }
}