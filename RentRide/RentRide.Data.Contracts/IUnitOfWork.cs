using System.Threading.Tasks;

namespace RentRide.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

    }
}
