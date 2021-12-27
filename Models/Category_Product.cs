using System;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class Category_Product
    {
        #region Columns
            public Guid ProductId { get; set; }
            public Guid CategoryId { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public virtual Product Product { get; set; }
            [JsonIgnore] public virtual Category Category { get; set; }
        #endregion
    }
}