using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.UserController.Authenticate
{
    public class RequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}