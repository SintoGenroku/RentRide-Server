using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentRide.Data;
using RentRide.DomainModels;
using RentRide.Foundation.Services.Abstracts;

namespace RentRide.Foundation.Services
{
    public class SalonService : ISalonService
    {
        private readonly IRentRideUnitOfWork _unitOfWork;

        public SalonService(IRentRideUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Salon> GetSalonById(Guid id)
        {
            var salon = await _unitOfWork.Salons.GetByIdAsync(id);

            return salon;
        }

        public IEnumerable<Salon> GetSalonsByName(string name)
        {
            var salons = _unitOfWork.Salons.GetByName(name);

            return salons;
        }

        public IEnumerable<Salon> GetSalonsByLocation(string location)
        {
            var salons = _unitOfWork.Salons.GetByLocation(location);

            return salons;
        }

        public async Task<IReadOnlyCollection<Salon>> GetSalonsAsync()
        {
            var salons = await _unitOfWork.Salons.GetAllAsync();

            return salons;
        }
        
        public async Task CreateSalonAsync(Salon salon)
        {
            await _unitOfWork.Salons.CreateAsync(salon);
        }

        public async Task UpdateSalonAsync(Salon salon)
        {
            await _unitOfWork.Salons.UpdateAsync(salon);
        }
    }
}