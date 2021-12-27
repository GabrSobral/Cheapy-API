using System;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class Feedback
    {
        #region Columns
            public Guid UserId { get; set; }
            public Guid ProductId { get; set; }
            public string Message { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public int Stars { get; set; }
        #endregion

        #region Navigations Objects
            [JsonIgnore] public virtual User User { get; set; }
            [JsonIgnore] public virtual Product Product { get; set; }
        #endregion
    }
}