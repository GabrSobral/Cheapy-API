using System;

namespace Cheapy_API.Controllers.CartItemController.MyList
{
    public class ResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Thumb { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
    }
}