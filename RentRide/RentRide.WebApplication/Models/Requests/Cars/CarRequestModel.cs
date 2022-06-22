using System;
using RentRide.WebApplication.Models.Requests.CarModels;

namespace RentRide.WebApplication.Models.Requests.Cars
{
    public class CarRequestModel
    {
        public Guid Id { get; set; }
        
        public string Brand { get; set; }
        
        public string SerialNumber { get; set; }
        
        public CarModelRequestModel CarModel { get; set; }
    }
}