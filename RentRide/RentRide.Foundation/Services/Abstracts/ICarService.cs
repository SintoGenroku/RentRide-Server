using RentRide.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentRide.Foundation.Services.Abstracts
{
    public interface ICarService
    {
        Task<Car> GetCarById(Guid id);

        IEnumerable<Car> GetCarsByBrand(string brand);

        Task<IReadOnlyCollection<Car>> GetCarsAsync();
        
        Task CreateCarAsync(Car car);

        Task UpdateCarAsync(Car car);

        Task DeleteCarAsync(Car car);
    }
}
