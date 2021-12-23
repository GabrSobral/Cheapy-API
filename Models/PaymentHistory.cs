using System;

namespace Cheapy_API.Models
{
    public class PaymentHistory
    {
        #region Columns
            public Guid UserId { get; set; }
            public Guid ProductId { get; set; }
            public float PaidValue { get; set; }
            public DateTime PaidAt { get; set; }
        #endregion

        #region Navigation Objects
            public virtual User User { get; set; }
            public virtual Product Product { get; set; }
        #endregion
    }
}