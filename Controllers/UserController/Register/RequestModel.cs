using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.UserController.Register
{
    public class RequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Role { get; set; }

        [Required]
        public string Token { get; set; }
    }
}