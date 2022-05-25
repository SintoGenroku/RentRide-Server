using System.Collections.Generic;

namespace RentRide.DomainModels
{
    public class Role : DomainObject
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
