using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.UserController.ConfirmationEmail
{
    public class RequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}