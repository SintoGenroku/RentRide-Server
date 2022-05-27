using RentRide.Data.Contracts;
using RentRide.Data.Repositories.Abstracts;

namespace RentRide.Data
{
    public interface IRentRideUntiOfWork : IUnitOfWork
    {
        ICarRepository Cars { get; }

        IContractRepository Contracts { get; }

        IRoleRepository Roles { get; }
        
        ISalonRepository Salons { get; }
        
        IUserRepository Users { get; }

    }
}
