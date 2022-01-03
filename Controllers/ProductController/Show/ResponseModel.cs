using System;
using System.Collections.Generic;
using Cheapy_API.Models;

namespace Cheapy_API.Controllers.ProductController.Show
{
    public class ResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public string Thumb { get; set; }
        public int Feedbacks { get; set; }
        public double AverageRating { get; set; }
        public UserResponseFormat Advertiser { get; set; }
        public List<Photos> Images { get; set; }
        public List<Category> Tags { get; set; }
    }
}