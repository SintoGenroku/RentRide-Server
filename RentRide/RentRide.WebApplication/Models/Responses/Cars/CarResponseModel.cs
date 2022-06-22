using System;
using RentRide.WebApplication.Models.Responses.CarModels;

namespace RentRide.WebApplication.Models.Responses.Cars
{
    public class CarResponseModel
    {
        public Guid Id { get; set; }
        
        public string Brand { get; set; }
        
        public string SerialNumber { get; set; }
        
        public CarModelResponseModel CarModel { get; set; }

    }
}