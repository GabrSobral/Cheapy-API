using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Cheapy_API.Models
{
    public class User
    {
        #region Columns
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public string Role { get; set; }
            public string Photo { get; set; }

            [JsonIgnore]
            public string Password { get; set; }
        #endregion

        #region Navigation Objects
            [JsonIgnore] public virtual List<Product> Products { get; set; }
            [JsonIgnore] public virtual List<Feedback> Feedbacks { get; set; }
            [JsonIgnore] public virtual List<ShoppingCart> ShoppingCarts { get; set; }
            [JsonIgnore] public virtual List<PaymentHistory> PaymentsHistory { get; set; }
        #endregion
    }
}