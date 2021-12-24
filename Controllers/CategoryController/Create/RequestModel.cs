using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.CategoryController.Create
{
    public class RequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}