namespace MinimalApiWithJwt.Models
{
    public class UserCredentialsWithoutPasswordDTO
    {
        public Guid Id = Guid.NewGuid();
        public string Username { get; set; }
        public string FavoriteDrink { get; set; }
    }
}
