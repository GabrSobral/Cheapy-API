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
        public int Quantity { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
        public Guid AdvertiserId { get; set; }

        public ResponseModel(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.CreatedAt = product.CreatedAt;
            this.Price = product.Price;
            this.Quantity = product.Quantity;
            this.Discount = product.Discount;
            this.AdvertiserId = product.AdvertiserId;
        }
    }
}