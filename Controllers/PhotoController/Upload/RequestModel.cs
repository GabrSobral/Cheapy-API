using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Cheapy_API.Controllers.PhotoController.Upload
{
    public class RequestModel
    {
        [Required]
        [Display(Name="Photo")]
        public IFormFile Photo { get; set; }

        [Required]
        public string ProductId { get; set; }
    }
}