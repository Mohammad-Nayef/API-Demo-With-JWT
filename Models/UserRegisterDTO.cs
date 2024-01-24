using System.ComponentModel.DataAnnotations;

namespace MinimalApiWithJwt.Models
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; }
        public string? FavoriteDrink { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
