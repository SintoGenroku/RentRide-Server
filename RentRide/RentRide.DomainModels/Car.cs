using System.Collections.Generic;

namespace RentRide.DomainModels
{
    public class Car : DomainObject
    {
        public string Brand { get; set; }
        public ICollection<CarModel> CarModels { get; set; }
        public string SerialNumber { get; set; }
        public User Renter { get; set; }
        public Salon Salon { get; set; }
        public Contract RentContract { get; set; }
        
    }
}
