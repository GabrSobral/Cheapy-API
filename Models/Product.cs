using System;
using System.Collections.Generic;

namespace Cheapy_API.Models
{
    public class Product
    {
        #region Columns
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public float Price { get; set; }
            public int Quantity { get; set; }
            public string Description { get; set; }
            public float Discount { get; set; }
            public Guid AdvertiserId { get; set; }
        #endregion

        #region Navigation Objects
            public virtual User Advertiser { get; set; }
            public virtual List<Category_Product> CategoryProduct { get; set; }
            public virtual List<Feedback> Feedbacks { get; set; }
            public virtual List<ShoppingCart> ShoppingCarts { get; set; }
        #endregion
    }
}