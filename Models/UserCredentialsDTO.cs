namespace MinimalApiWithJwt.Models
{
    public class UserCredentialsDTO
    {
        public Guid Id = Guid.NewGuid();
        public string Username { get; set; }
        public string FavoriteDrink { get; set; }
        public string Password { get; set; }
    }
}
