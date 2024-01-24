namespace MinimalApiWithJwt.Models
{
    public class UserWithoutPasswordDTO
    {
        public Guid Id { get; }
        public string Username { get; set; }
        public string FavoriteDrink { get; set; }
    }
}
