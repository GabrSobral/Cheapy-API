using System;
using Cheapy_API.Models;

namespace Cheapy_API.Controllers.ProductController.Create
{
    public class ResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
        public string AdvertiserId { get; set; }
        public string Thumb { get; set; }

        public ResponseModel(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.CreatedAt = product.CreatedAt;
            this.Price = product.Price;
            this.Stock = product.Stock;
            this.Discount = product.Discount;
            this.AdvertiserId = product.AdvertiserId;
            this.Thumb = product.ThumbUrl;
        }
    }
}