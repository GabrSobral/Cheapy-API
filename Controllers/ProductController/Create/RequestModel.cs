using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.ProductController.Create
{
    public class RequestModel
    {   
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Advertiser is required")]
        public Guid Advertiser { get; set; }
    }
}