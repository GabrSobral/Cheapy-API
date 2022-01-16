using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.ProductTagController.Delete
{
    public class RequestModel
    {
        [Required(ErrorMessage = "Product ID is required")]
        public Guid Product_Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}