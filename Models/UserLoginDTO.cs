using System.ComponentModel.DataAnnotations;

namespace MinimalApiWithJwt.Models
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
