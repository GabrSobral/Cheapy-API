using Microsoft.IdentityModel.Tokens;
using Cheapy_API.Settings;
using Microsoft.Extensions.Options;
using Cheapy_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Cheapy_API.Services
{
    public class JsonWebToken
    {
        private JwtSecret _jwtSecret { get; set; }
        private IConfiguration Configuration { get; set; }

        public JsonWebToken(IOptions<JwtSecret> options) => _jwtSecret = options.Value;

        public string Generate(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new [] {
                    new Claim("Id", userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
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