using System;

namespace RentRide.WebApplication.Models.Responses.Users
{
    public class UserResponseModel
    {
        public Guid Id { get; set; }
        
        public string UserName { get; set; }
        
        public DateTime CreationTime { get; set; }
    }
}