using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.FavoriteController.Mark
{
    public class Service
    {
        public async Task Execute(
            AppDbContext context, 
            Guid userId, 
            Guid productId)
        {
            var favorite = await context.Favorites
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);

            if(favorite == null)
            {
                favorite = new Favorite
                {
                    UserId = userId,
                    ProductId = productId
                };
                await context.AddAsync(favorite);
            }
            else
                context.Remove(favorite);

            await context.SaveChangesAsync();
            return;
        }
    }
}