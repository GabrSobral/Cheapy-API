using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cheapy_API.Models
{
    public class Order
    {
        #region Columns
            public Guid     Id { get; set; } = Guid.NewGuid();
            public string   Status { get; set; }
            public string   UserId { get; set; }
            public string   UserEmail { get; set; }
            public string   Country { get; set; }
            public string   City { get; set; }
            public string   PostalCode { get; set; }
            public string   ShipPostalCode { get; set; }
            public string   AdvertiserId { get; set; }
            public string   PaymentProvider { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        #endregion
       
        #region Navigation Objects
            [JsonIgnore] public virtual User User { get; set; }
            [JsonIgnore] public virtual User Advertiser { get; set; }
            [JsonIgnore] public virtual List<OrderItem> OrderItems { get; set; }
        #endregion

    }
}