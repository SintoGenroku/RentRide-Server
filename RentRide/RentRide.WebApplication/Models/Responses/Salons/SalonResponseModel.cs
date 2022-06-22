using System;
using System.Collections.Generic;
using RentRide.WebApplication.Models.Responses.Cars;
using RentRide.WebApplication.Models.Responses.Contracts;

namespace RentRide.WebApplication.Models.Responses.Salons
{
    public class SalonResponseModel
    {
        public Guid Id { get; set; }
        
        public string Location { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<CarResponseModel> Cars { get; set; }
        
        public ICollection<ContractResponseModel> Contracts { get; set; }
    }
}