using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.FeedbackController.Create
{
    public class RequestModel
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Boolean Recomendation { get; set; }
        [Required]
        public int Stars { get; set; }
    }
}