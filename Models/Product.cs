using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class Product
    {
        #region Columns
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public float Price { get; set; }
            public int Stock { get; set; }
            public string Description { get; set; }
            public float Discount { get; set; }
            public Guid AdvertiserId { get; set; }
            public string ThumbUrl { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public virtual User Advertiser { get; set; }
            [JsonIgnore] public virtual List<Product_Tags> ProductTags { get; set; }
            [JsonIgnore] public virtual List<Feedback> Feedbacks { get; set; }
            [JsonIgnore] public virtual List<CartItem> CartItems { get; set; }
            [JsonIgnore] public virtual List<OrderItem> OrderItems { get; set; }
            [JsonIgnore] public virtual List<Photos> Photos { get; set; }
            [JsonIgnore] public virtual List<Favorite> Favorites { get; set; }
        #endregion
    }
}