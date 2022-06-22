using System;
using RentRide.DomainModels;
using RentRide.WebApplication.Models.Requests.Cars;
using RentRide.WebApplication.Models.Requests.Salons;
using RentRide.WebApplication.Models.Responses.Cars;
using RentRide.WebApplication.Models.Responses.Users;

namespace RentRide.WebApplication.Models.Requests.Contracts
{
    public class ContractRequestModel
    {
        public Guid Id { get; set; }
        
        public DateTime ConclusionDate { get; set; }
        
        public DateTime EndOfContractDate { get; set; }
        
        public SalonRequestModel Salon { get; set; }
        
        public decimal TotalRentPrice { get; set; }
        
        public CarRequestModel Car { get; set; }
        
        public Guid CarId { get; set; }
    }
}