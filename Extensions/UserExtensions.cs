using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Extensions
{
    public static class UserExtensions
    {
        public static UserDTO Matches(
            this IEnumerable<UserDTO> users, UserLoginDTO userLogin)
        {
            return users.FirstOrDefault(user =>
            {
                if (user.Username == userLogin.Username &&
                    user.Password == userLogin.Password)
                    return true;

                return false;
            });
        }
    }
}
