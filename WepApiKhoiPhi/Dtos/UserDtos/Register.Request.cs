using System.ComponentModel.DataAnnotations;
using WepApiKhoiPhi.Models;

namespace WepApiKhoiPhi.Dtos.UserDtos
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        public Role Role { get; set; }

        [Required]
        public string Password { get; set; }
    }
}