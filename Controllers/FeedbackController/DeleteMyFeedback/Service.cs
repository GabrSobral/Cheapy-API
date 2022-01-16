using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.FeedbackController.DeleteMyFeedback
{
    public class Service
    {
        public async Task Execute(AppDbContext context, Guid productId, string userId)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:404");

            var feedback = await context.Feedbacks
                .AsNoTracking()
                .FirstOrDefaultAsync(x => ((x.ProductId == productId) && (x.UserId == userId)));
            
            if(feedback == null)
                throw new Exception("You don't have feedbacks of this product yet status:400");
            
            context.Feedbacks.Remove(feedback);
            await context.SaveChangesAsync();
        }
    }
}