using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cheapy_API.Models
{
    public class Category_Product
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}