using System;

namespace Cheapy_API.Models
{
    public class ShoppingCart
    {
        #region Columns
            public Guid UserId { get; set; }
            public Guid ProductId { get; set; }
            public int ProductQuantity { get; set; }
        #endregion

        #region Navigation Objects
            public virtual User User { get; set; }
            public virtual Product Product { get; set; }
        #endregion

    }
}