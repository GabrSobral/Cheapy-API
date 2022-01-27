using System;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class RefreshToken
    {
        #region Columns
            public Guid Id { get; set; } = Guid.NewGuid();
            public DateTime ExpiresIn { get; set; }
            public Guid UserId { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public User User { get; set; }
        #endregion
    }
}