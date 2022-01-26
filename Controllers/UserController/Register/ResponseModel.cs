using System;
using Cheapy_API.Models;

namespace Cheapy_API.Controllers.UserController.Register
{
    public class ResponseModel
    {
        public User User { get; set; }
        public string Token { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public ResponseModel(User user, string token, RefreshToken refreshToken)
        {
            this.User = user;
            this.Token = token;
            this.RefreshToken = refreshToken;
        }
    }

    public class TokenDescrypted
    {
        public string Email { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}