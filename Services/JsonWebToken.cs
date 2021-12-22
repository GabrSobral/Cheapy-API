using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Cheapy_API.Settings;
using Microsoft.Extensions.Options;
using Cheapy_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Text;

namespace Cheapy_API.Services
{
    public class JsonWebToken
    {
        private JwtSecret _jwtSecret { get; set; }

        public JsonWebToken(IOptions<JwtSecret> options) => _jwtSecret = options.Value;

        public string Generate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new [] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Role", user.Role)
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