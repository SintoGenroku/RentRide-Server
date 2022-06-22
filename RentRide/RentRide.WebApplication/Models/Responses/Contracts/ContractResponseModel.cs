using System;
using RentRide.DomainModels;
using RentRide.WebApplication.Models.Responses.Cars;
using RentRide.WebApplication.Models.Responses.Users;

namespace RentRide.WebApplication.Models.Responses.Contracts
{
    public class ContractResponseModel
    {
        public Guid Id { get; set; }
        
        public UserResponseModel Client { get; set; }
        
        public DateTime ConclusionDate { get; set; }
        
        public DateTime EndOfContractDate { get; set; }
        
        public Salon Salon { get; set; }
        
        public decimal TotalRentPrice { get; set; }
        
        public CarResponseModel Car { get; set; }
        
        public Guid CarId { get; set; }
    }
}