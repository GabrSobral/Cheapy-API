using Microsoft.AspNetCore.Http;

namespace Cheapy_API.Controllers.UserController.UpdateData
{
    public class RequestModel
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}