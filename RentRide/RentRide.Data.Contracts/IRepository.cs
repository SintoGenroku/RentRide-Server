using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentRide.Data.Contracts
{
    public interface IRepository<T>
    {
        Task CreateAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(T item);

        Task<T> FindByIdAsync(params object[] KeyVakues);

        Task<IReadOnlyCollection<T>> GetAllAsync();
    }
}
