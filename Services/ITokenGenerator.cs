using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Services
{
    /// <summary>
    /// Responsible for dealing with web tokens for authorizing requests.
    /// </summary>
    public interface ITokenGenerator
    {
        /// <summary>
        /// Generates a web token based on the user.
        /// </summary>
        /// <returns>String value of the token.</returns>
        string GenerateToken(UserWithoutPasswordDTO user);

        /// <summary>
        /// Checks whether the token is valid and didn't expire yet.
        /// </summary>
        /// <param name="token">A web token to be validated.</param>
        /// <returns>true if the token is valid; otherwise, false.</returns>
        bool ValidateToken(string token);
    }
}