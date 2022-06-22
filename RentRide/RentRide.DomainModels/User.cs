using System;
using System.Collections.Generic;

namespace RentRide.DomainModels
{
    public class User
    {
        public Guid Id { get; set; }

        public string Fullname{ get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        
    }
}