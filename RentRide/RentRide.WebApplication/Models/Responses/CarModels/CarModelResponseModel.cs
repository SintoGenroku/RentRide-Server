using System;

namespace RentRide.WebApplication.Models.Responses.CarModels
{
    public class CarModelResponseModel
    {
        public Guid Id { get; set; }
        
        public int Year { get; set; }
        
        public string Model { get; set; }
        
        public string Engine { get; set; }
        
        public string Carcase { get; set; }
        
        public string Color { get; set; }
        
        public decimal Price { get; set; }
        
        public float RentCoefficient { get; set; }
        
    }
}