using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace Cheapy_API.Controllers.PaymentGatewayController.Checkout
{
    public class Service
    {
        public async Task<Object> Execute(
            AppDbContext context, 
            Guid userId,
            List<RequestModel> model)
        {
            var products = new List<SessionLineItemOptions>();
            var user = await context.Users
                .Where(x => x.Id == userId)
                .Select(x => new { x.Email })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            foreach (var item in model)
            {
                var product = await context.Products
                    .Where(x => x.Id == item.ProductId)
                    .Select(x => new { x.Name, x.Price, x.Discount, x.ThumbUrl })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var LineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = int.Parse((
                                product.Price -(product.Price * product.Discount)).ToString()),
                            Currency = "brl",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = product.Name,
                                Images = new List<string>(){ product.ThumbUrl },
                            },

                        },
                    Quantity = item.Quantity
                };
                products.Add(LineItem);
            };

            var options = new SessionCreateOptions
            {
                LineItems = products,
                Mode = "payment",
                SuccessUrl = "http://localhost:3000/SuccessPayment",
                CancelUrl = "http://localhost:3000/Profile",
                CustomerEmail = user.Email
            };

            var service = new SessionService();
            var session = service.Create(options);

            return new { Url = session.Url };
        }
    }
}