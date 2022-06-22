using System.Collections.Generic;
using System.Threading.Tasks;
using RentRide.DomainModels;

namespace RentRide.Foundation.Services.Abstracts
{
    public interface ICarModelService
    {
        Task<IReadOnlyCollection<CarModel>> GetCarModelsAsync();
    }
}