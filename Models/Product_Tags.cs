using System;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class Product_Tags
    {
        #region Columns
            public Guid ProductId { get; set; }
            public string Name { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public virtual Product Product { get; set; }
        #endregion
    }
}