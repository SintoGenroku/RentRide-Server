using Microsoft.EntityFrameworkCore;
using RentRide.Data.Core;
using RentRide.Data.Repositories.Abstracts;
using RentRide.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentRide.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(RentRideDbContext context) : base(context)
        {
        }

        public async Task<Car> GetByIdAsync(Guid id)
        {
            var car = await GetCarsQuery()
                .FirstOrDefaultAsync(car => car.Id == id);

            return car;
        }

        public IEnumerable<Car> GetBySalonId(Guid id)
        {
            var cars = GetCarsQuery()
                .Where(car => car.Salon.Id == id);

            return cars;
        }

        public IEnumerable<Car> GetByBrand(string brand)
        {
            var car = GetCarsQuery()
                .Where(car => car.Brand == brand);
            return car;
        }

        private IQueryable<Car> GetCarsQuery()
        {
            return Data
                .Include(car => car.Salon)
                .Include(car => car.CarModel)
                .Include(car => car.RentContract);
        }
    }
}
