using System;
using System.Collections.Generic;

namespace RentRide.DomainModels
{
    public class Role : IEquatable<Role>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public bool Equals(Role other)
        {
            return Id == other.Id;
        }
    }
}
