using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Cheapy_API.Models
{
    public class User
    {
        #region Columns
            public Guid Id { get; set; } = Guid.NewGuid();
            public string CPF { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Photo { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Telephone { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;

            [JsonIgnore]
            public string Password { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public virtual List<Product> Products { get; set; }
            [JsonIgnore] public virtual List<Feedback> Feedbacks { get; set; }
            [JsonIgnore] public virtual List<CartItem> CartItems { get; set; }
            [JsonIgnore] public virtual List<Order> OrdersByUser { get; set; }
            [JsonIgnore] public virtual List<Order> OrdersByAdvertiser { get; set; }
            [JsonIgnore] public virtual List<RefreshToken> RefreshTokens { get; set; }
            [JsonIgnore] public virtual List<Favorite> Favorites { get; set; }
        #endregion
    }
}