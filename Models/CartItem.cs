using System;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class CartItem
    {
        #region Columns
            public string UserId { get; set; }
            public Guid ProductId { get; set; }
            public int ProductQuantity { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public virtual User User { get; set; }
            [JsonIgnore] public virtual Product Product { get; set; }
        #endregion

    }
}