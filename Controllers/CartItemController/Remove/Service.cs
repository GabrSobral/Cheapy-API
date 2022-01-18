using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Models;
using System;

namespace Cheapy_API.Controllers.CartItemController.Remove
{
    public class Service
    {
        public async Task Execute(AppDbContext context, Guid userId, Guid productId)
        {
            CartItem cartItem = new CartItem{ ProductId = productId };
            context.CartItems.Attach(cartItem);
            context.CartItems.Remove(cartItem);
            await context.SaveChangesAsync();
        } 
    }
}