using System;

namespace RentRide.WebApplication.Models.Requests.Cars
{
    public class EditCarRequestModel
    {
        public Guid Id { get; set; }
        
        public string SerialNumber { get; set; }
        
        public string CarModelEngine { get; set; }

        public string CarModelColor { get; set; }
        
        public decimal CarModelPrice { get; set; }
        
        public float CarModelRentCoefficient { get; set; }
    }
}