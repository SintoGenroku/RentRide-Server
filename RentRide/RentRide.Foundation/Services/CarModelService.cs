using System.Collections.Generic;
using System.Threading.Tasks;
using RentRide.Data;
using RentRide.DomainModels;
using RentRide.Foundation.Services.Abstracts;

namespace RentRide.Foundation.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly IRentRideUnitOfWork _unitOfWork;

        public CarModelService(IRentRideUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<CarModel>> GetCarModelsAsync()
        {
            var carModels = await _unitOfWork.CarModels.GetAllAsync();

            return carModels;
        }
    }
}