using System;
using Cheapy_API.Models;

namespace Cheapy_API.Controllers.UserController.Register
{
    public class ResponseModel
    {
        public User User { get; set; }
        public string Token { get; set; }

        public ResponseModel(User user, string token)
        {
            this.User = user;
            this.Token = token;
        }
    }

    public class TokenDescrypted
    {
        public string Email { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}