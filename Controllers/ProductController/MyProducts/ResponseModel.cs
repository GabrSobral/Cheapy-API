using System;
using Cheapy_API.Models;

namespace Cheapy_API.Controllers.ProductController.MyProducts
{
    public class ResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public string Thumb { get; set; }
        public double AverageRating { get; set; }
    }
}