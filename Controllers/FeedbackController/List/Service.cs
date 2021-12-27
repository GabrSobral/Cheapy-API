using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cheapy_API.Controllers.FeedbackController.List
{
    public class Service
    {
        public async Task<List<Feedback>> Execute(AppDbContext context, Guid productId)
        {
            
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:404");

            var feedbacks = await context.Feedbacks
                .Where(x => x.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();

            return feedbacks;
        }
    }
}