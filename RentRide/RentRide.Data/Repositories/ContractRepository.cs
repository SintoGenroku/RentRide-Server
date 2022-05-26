using Microsoft.EntityFrameworkCore;
using RentRide.Data.Core;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {

        public ContractRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Contract> GetByClientId(Guid id)
        {
            var contracts = GetContractsQuery().
                Where(contract => contract.Client.Id == id);

            return contracts;
        }

        public IEnumerable<Contract> GetByDateAsync(DateTime? Date)
        {
            var contracts = GetContractsQuery().
                Where(contract => contract.ConclusionDate <= Date & contract.EndOfContractDate >= Date);

            return contracts;
        }

        public async Task<Contract> GetByIdAsync(Guid id)
        {
            var contracts = await GetContractsQuery().
                FirstOrDefaultAsync(contract => contract.Id == id);

            return contracts;
        }

        public IEnumerable<Contract> GetBySalonId(Guid id)
        {
            var contracts = GetContractsQuery().
               Where(contract => contract.Salon.Id == id);

            return contracts;
        }

        private IQueryable<Contract> GetContractsQuery()
        {
            return Data
                .Include(contract => contract.Car)
                .Include(contract => contract.Salon)
                .Include(contract => contract.Client);
        }
    }
}
