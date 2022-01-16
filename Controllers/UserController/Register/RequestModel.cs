using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.UserController.Register
{
    public class RequestModel
    {
        [Required] public string Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }
        
        [Required] public string Token { get; set; }

        [Required] public string Country { get; set; }

        [Required] public string City { get; set; }

        [Required] public string PostalCode { get; set; }

        [Required] public string State { get; set; }
    }
}