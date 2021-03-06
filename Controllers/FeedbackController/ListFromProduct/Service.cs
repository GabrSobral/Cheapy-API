using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cheapy_API.Controllers.FeedbackController.ListFromProduct
{
    public class Service
    {
        public async Task<Result> Execute(
            AppDbContext context, 
            Guid productId, 
            int page, 
            Guid userId )
        {
            int limit = 5;
            page = page == 0 ? 0 : page;

            var result = new Result{
                Feedbacks = null,
                MyFeedback = null
            };

            if(userId != Guid.Empty)
            {
                result.MyFeedback = await context.Feedbacks
                    .Where(x => (x.ProductId == productId) && (x.UserId == userId))
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
                            User = new 
                            {
                                Id = users.Id,
                                Email = users.Email,
                                Name = users.Name,
                                Photo = users.Photo == null ? "" : $"https://localhost:5001/Uploads/{users.Photo}" 
                            }
                        }
                    )
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }

            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:400");

            result.Feedbacks = await context.Feedbacks
                .Where(x => (x.ProductId == productId) && (x.UserId != userId))
                .OrderBy(x => x.CreatedAt)
                .Skip(page * limit)
                .Take(limit)
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
                        User = new 
                        {
                            Id = users.Id,
                            Email = users.Email,
                            Name = users.Name,
                            Photo = users.Photo == null ? "" : $"https://localhost:5001/Uploads/{users.Photo}" 
                        }
                    }
                )
                .AsNoTracking()
                .ToListAsync();

            return result;
        }
    }
}