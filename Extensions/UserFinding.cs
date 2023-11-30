using MinimalApiWithJwt.Models;
using MinimalApiWithJwt.Services;

namespace MinimalApiWithJwt.Extensions
{
    public static class UserFinding
    {
        public static UserDTO FindUserByCredentials(
            this UserLoginDTO userLogin, 
            IUserService userService)
        {
            return userService.GetAll().FirstOrDefault(user =>
            {
                if (user.Username == userLogin.Username &&
                    user.Password == userLogin.Password)
                    return true;

                return false;
            });
        }
    }
}
