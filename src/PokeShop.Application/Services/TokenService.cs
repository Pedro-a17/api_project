using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace PokeShop.Application.Services
{
    public class TokenService : ITokenService
    {
        readonly IConfiguration _config;

        public TokenService(IConfiguration configuration) => _config = configuration;

        public string jwtTokenGenerator(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _config["JwtSettings:Secret"];
            
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("jwt's secret ket not configured");
            }

            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
              Subject = new ClaimsIdentity(new[]
              {
                  new Claim(ClaimTypes.NameIdentifier, userId.ToString())
              }),
              Expires = DateTime.UtcNow.AddHours(2),
              SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
              )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}