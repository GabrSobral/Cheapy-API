using System;

namespace Cheapy_API.Controllers.PaymentGatewayController.Checkout
{
    public class RequestModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}