using System;
using System.Collections.Generic;
using RentRide.WebApplication.Models.Requests.Cars;
using RentRide.WebApplication.Models.Requests.Contracts;

namespace RentRide.WebApplication.Models.Requests.Salons
{
    public class SalonRequestModel
    {
        public Guid Id { get; set; }
        
        public string Location { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<CarRequestModel> Cars { get; set; }
        
        public ICollection<ContractRequestModel> Contracts { get; set; }
    }
}