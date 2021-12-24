using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.ProductController.Create
{
    public class RequestModel
    {   
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid Advertiser { get; set; }
    }
}