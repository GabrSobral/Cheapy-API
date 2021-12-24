using System;

namespace Cheapy_API.Models
{
    public class Feedback
    {
        #region Columns
            public Guid UserId { get; set; }
            public Guid ProductId { get; set; }
            public string Message { get; set; }
            public DateTime CreatedAt { get; set; }
            public int Stars { get; set; }
        #endregion

        #region Navigations Objects
            public virtual User User { get; set; }
            public virtual Product Product { get; set; }
        #endregion
    }
}