using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cheapy_API.Controllers.FeedbackController.ListFromProduct
{
    public class Service
    {
        public async Task<List<ResponseModel>> Execute(AppDbContext context, Guid productId)
        {
            
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:404");

            var feedbacks = await context.Feedbacks
                .Where(x => x.ProductId == productId)
                .Join(
                    context.Users,
                    feedbacks => feedbacks.UserId,
                    users => users.Id,
                    (feedbacks, users) => new ResponseModel
                    {
                        Title = feedbacks.Title,
                        Message = feedbacks.Message,
                        CreatedAt = feedbacks.CreatedAt,
                        Stars = feedbacks.Stars,
                        Recomendation = feedbacks.Recomendation,
                        User = users
                    }
                )
                .AsNoTracking()
                .ToListAsync();

            return feedbacks;
        }
    }
}