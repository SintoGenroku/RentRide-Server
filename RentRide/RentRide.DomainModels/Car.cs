using System;

namespace RentRide.DomainModels
{
    public class Car : DomainObject
    {
        public string Brand { get; set; }
        public CarModel CarModel { get; set; }
        public Guid CarModelId { get; set; }
        public Salon Salon { get; set; }
        public Contract RentContract { get; set; }
        public string SerialNumber { get; set; }

    }
}
