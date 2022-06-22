using System.ComponentModel.DataAnnotations;

namespace RentRide.WebApplication.Models.Requests.Users
{
    public class UserLoginRequestModel
    {
        [Required(ErrorMessage = "Please Enter your Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please Enter your Password")]
        public string Password { get; set; }
    }
}