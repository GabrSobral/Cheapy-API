using System;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class OrderItem
    {
        #region Columns
            public Guid ProductId { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }
            public string Name { get; set; }
            public Guid OrderId { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public Order Order { get; set; }
            [JsonIgnore] public Product Product { get; set; }
        #endregion
    }
}