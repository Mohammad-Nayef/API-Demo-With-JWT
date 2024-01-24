using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Services
{
    /// <summary>
    /// Responsible for dealing with JWT as an authorization token.
    /// </summary>
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _config;

        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UserWithoutPasswordDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            double expirationMinutes;

            if (!double.TryParse(_config["Jwt:ExpirationMinutes"], out expirationMinutes))
                throw new InvalidCastException("Invalid 'Jwt:ExpirationMinutes' in appsettings.json");

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(expirationMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
            };

            try
            {
                token = token
                    .Trim()
                    .Replace("Bearer ", string.Empty);

                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(
                    token, 
                    validationParameters, 
                    out var validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
