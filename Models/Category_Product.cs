using System;

namespace Cheapy_API.Models
{
    public class Category_Product
    {
        #region Columns
            public Guid ProductId { get; set; }
            public Guid CategoryId { get; set; }
        #endregion

        #region Navigation Objects
            public virtual Product Product { get; set; }
            public virtual Category Category { get; set; }
        #endregion
    }
}