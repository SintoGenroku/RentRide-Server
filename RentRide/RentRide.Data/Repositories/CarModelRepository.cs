using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentRide.Data.Core;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;

namespace RentRide.Data.Repositories
{
    public class CarModelRepository : Repository<CarModel>, ICarModelRepository
    {
        public CarModelRepository(RentRideDbContext context):
            base(context){ }
        public async Task<CarModel> GetByIdAsync(Guid id)
        {
            var carModel = await Data.FirstOrDefaultAsync(carModel => carModel.Id == id);

            return carModel;
        }

        public IEnumerable<CarModel> GetByModel(string model)
        {
            var carModels = Data.Where(carModel => carModel.Model == model);

            return carModels;
        }

        public bool FindAsync(CarModel carModel)
        {
            var isExist = Data.Contains(carModel);
            return isExist;
        }
    }
}