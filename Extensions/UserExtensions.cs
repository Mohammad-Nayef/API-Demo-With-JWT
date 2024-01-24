using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Extensions
{
    public static class UserExtensions
    {
        /// <summary>
        /// Returns a user that matches the login credentials or null if none matched.
        /// </summary>
        public static UserDTO FindMatchingUser(
            this IEnumerable<UserDTO> users, UserLoginDTO userLogin)
        {
            return users.FirstOrDefault(user =>
                    user.Username == userLogin.Username &&
                    user.Password == userLogin.Password
                );
        }
    }
}
