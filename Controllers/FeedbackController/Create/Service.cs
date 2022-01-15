using System.Threading.Tasks;
using System;
using System.Linq;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.FeedbackController.Create
{
    public class Service
    {
        public async Task<Feedback> Execute(
            AppDbContext context, 
            RequestModel model, 
            string userId,
            Guid productId)
        {
            var product = await context.Products
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:404");
                
            var feedback = await context.Feedbacks
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if(feedback == null)
            {
                var newFeedback = new Feedback
                {
                    UserId = userId,
                    ProductId = productId,
                    Message = model.Message,
                    Stars = model.Stars,
                    Title = model.Title,
                    Recomendation = model.Recomendation
                };
                await context.Feedbacks.AddAsync(newFeedback);
                await context.SaveChangesAsync();

                return newFeedback;
            }

            feedback.Message = model.Message;
            feedback.Stars = model.Stars;
            feedback.Title = model.Title;
            feedback.Recomendation = model.Recomendation;

            context.Feedbacks.Update(feedback);
            await context.SaveChangesAsync();

            return feedback;
        } 
    }
}