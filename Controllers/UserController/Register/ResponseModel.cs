using Cheapy_API.Models;

namespace Cheapy_API.Controllers.UserController.Register
{
    public class ResponseModel
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}