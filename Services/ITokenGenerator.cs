using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserWithoutPasswordDTO user);
        bool ValidateToken(string token);
    }
}