using System;

namespace RentRide.DomainModels
{
    public class Contract : DomainObject
    {
        public User Client { get; set; }
        public DateTime ConclusionDate { get; set; }
        public DateTime EndOfContractDate { get; set; }
        public Salon Salon { get; set; }
        public decimal TotalRentPrice { get; set; }
        public Car Car { get; set; }
        public Guid CarId { get; set; }
    }
}
