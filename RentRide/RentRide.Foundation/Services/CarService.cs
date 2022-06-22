using RentRide.Data;
using RentRide.DomainModels;
using RentRide.Foundation.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentRide.Foundation.Services
{
    public class CarService : ICarService
    {
        private readonly IRentRideUnitOfWork _unitOfWork;

        public CarService(IRentRideUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> GetCarById(Guid Id)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(Id);
            
            return car;
        }

        public IEnumerable<Car> GetCarsByBrand(string brand)
        {
            var cars =  _unitOfWork.Cars.GetByBrand(brand);

            return cars;
        }

        public async Task<IReadOnlyCollection<Car>> GetCarsAsync()
        {
            var cars = await _unitOfWork.Cars.GetAllAsync();

            return cars;
        }

        public async Task CreateCarAsync(Car car)
        {
            await _unitOfWork.Cars.CreateAsync(car);
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _unitOfWork.Cars.UpdateAsync(car);
        }

        public async Task DeleteCarAsync(Car car)
        {
            await _unitOfWork.Cars.DeleteAsync(car);
        }
    }
}
