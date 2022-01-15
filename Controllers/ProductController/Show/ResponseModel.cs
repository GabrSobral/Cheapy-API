using System;
using System.Collections.Generic;

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
        public UserFormat Advertiser { get; set; }
        public List<ImageFormat> Images { get; set; }
        public List<TagFormat> Tags { get; set; }
    }

    public class ImageFormat
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
    }

    public class UserFormat
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class TagFormat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}