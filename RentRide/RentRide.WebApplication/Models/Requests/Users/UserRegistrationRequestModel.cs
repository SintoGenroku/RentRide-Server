using System.ComponentModel.DataAnnotations;

namespace RentRide.WebApplication.Models.Requests.Users
{
    public class UserRegistrationRequestModel
    {
        [Required(ErrorMessage = "Fullname cannot be empty")]
        public string Fullname { get; set; }
        
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password cannot be empty")]
        [MinLength(6, ErrorMessage = "Password cannot be shorter than 6 symbols")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please repeat your password to confirm it")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}