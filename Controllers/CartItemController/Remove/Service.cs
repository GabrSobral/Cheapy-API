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
            var cartItem = new CartItem{ ProductId = productId, UserId = userId };
            context.Remove(cartItem);
            await context.SaveChangesAsync();
        } 
    }
}