using System;

namespace Cheapy_API.Controllers.ShoppingCartsController.Add
{
    public class RequestModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}