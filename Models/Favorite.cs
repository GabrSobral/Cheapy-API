using System;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class Favorite
    {
        #region Columns
            public Guid ProductId { get; set; }
            public Guid UserId { get; set; }
        #endregion

        #region  Navigation Objects
            [JsonIgnore] public User User { get; set; }
            [JsonIgnore] public Product Product { get; set; }
        #endregion
    }
}