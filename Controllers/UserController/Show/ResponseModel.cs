using Cheapy_API.Models;

namespace Cheapy_API.Controllers.UserController.Show
{
    public class ResponseModel
    {
        public User User { get; set; }
        public UserSoft UserSoft { get; set; }
    }

    public class UserSoft 
    {
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}