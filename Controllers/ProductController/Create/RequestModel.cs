using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.ProductController.Create
{
    public class RequestModel
    {   
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Thumb is required")]
        public string Thumb { get; set; }
    }
}