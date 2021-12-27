using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.CategoryProductController.Create
{
    public class RequestModel
    {
        [Required(ErrorMessage = "Product ID is required")]
        public Guid Product_Id { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public Guid Category_id { get; set; }
    }
}