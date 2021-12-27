using Cheapy_API.Models;

namespace Cheapy_API.Controllers.UserController.Authenticate
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
}