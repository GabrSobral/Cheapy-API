using System;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class Photos
    {   
        #region Columns
            public Guid Id { get; set; } = Guid.NewGuid();
            public Guid ProductId { get; set; }
            public string Url { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public virtual Product Product { get; set; }
        #endregion
    }
}