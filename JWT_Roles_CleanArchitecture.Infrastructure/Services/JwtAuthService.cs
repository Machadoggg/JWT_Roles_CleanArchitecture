using JWT_Roles_CleanArchitecture.Core.Entities;
using JWT_Roles_CleanArchitecture.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Roles_CleanArchitecture.Infrastructure.Services
{
    public class JwtAuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public JwtAuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]!);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["JwtAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:ExpireMinutes"]!)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateUser(string username, string password)
        {
            // Valida el usuario (esto debería ser desde la base de datos)
            return username == "admin" && password == "password" || username == "user" && password == "password";
        }
    }
}
