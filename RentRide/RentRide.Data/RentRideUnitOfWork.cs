using RentRide.Data.Contracts;
using RentRide.Data.Core;
using RentRide.Data.Repositories;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentRide.Data
{
    public class RentRideUnitOfWork : UnitOfWork, IRentRideUntiOfWork
    {
        public ICarRepository Cars => 
            (ICarRepository)GetRepository<Car>();

        public IContractRepository Contracts => 
            (IContractRepository)GetRepository<Contract>();

        public IRoleRepository Roles => 
            (IRoleRepository)GetRepository<Role>();

        public ISalonRepository Salons => 
            (ISalonRepository)GetRepository<Salon>();

        public IUserRepository Users => 
            (IUserRepository)GetRepository<User>();


        public RentRideUnitOfWork(RentRideDbContext context) : base(context)
        {
            AddSpecificRepository<Car, CarRepository>();
            AddSpecificRepository<Contract, ContractRepository>();
            AddSpecificRepository<Role, RoleRepository>();
            AddSpecificRepository<Salon, SalonRepository>();
        }
    }
}
