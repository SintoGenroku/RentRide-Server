using System.Collections.Generic;

namespace RentRide.DomainModels
{
    public class Salon : DomainObject
    {
        public string Location { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
