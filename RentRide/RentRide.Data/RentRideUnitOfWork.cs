using RentRide.Data.Core;
using RentRide.Data.Repositories;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;

namespace RentRide.Data
{
    public class RentRideUnitOfWork : UnitOfWork, IRentRideUnitOfWork
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

        public ICarModelRepository CarModels =>
            (ICarModelRepository)GetRepository<CarModel>();


        public RentRideUnitOfWork(RentRideDbContext context) : base(context)
        {
            AddSpecificRepository<Car, CarRepository>();
            AddSpecificRepository<Contract, ContractRepository>();
            AddSpecificRepository<Role, RoleRepository>();
            AddSpecificRepository<User, UserRepository>();
            AddSpecificRepository<Salon, SalonRepository>();
            AddSpecificRepository<CarModel, CarModelRepository >();
        }
    }
}
