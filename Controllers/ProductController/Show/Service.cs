using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ProductController.Show
{
    public class Service
    {
        public async Task<ResponseModel> Execute(AppDbContext context, Guid productId, Guid userId)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:400");

            var categories = await context.CategoriesProducts
                .Where(x => x.ProductId == productId)
                .Join(
                    context.Categories,
                    categoryProduct => categoryProduct.CategoryId,
                    category => category.Id,
                    (categoryProduct, category) => new Category
                    {
                        Id = category.Id,
                        Name = category.Name
                    }
                )
                .AsNoTracking()
                .ToListAsync();

            var images = await context.Photos
                .Where(x => x.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();
            
            foreach(Photos image in images)
            {
                image.Url = $"https://localhost:5001/Uploads/{image.Url}";
            }

            var feedbacksSumAndCount = await (
                    from feedbacks in context.Feedbacks 
                    where feedbacks.ProductId == productId  
                    group feedbacks by feedbacks.ProductId into grp
                    select new 
                    {
                        Feedbacks = grp.Count(),
                        AverageRating = grp.Average(x => x.Stars)
                    }
                )
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var advertiser = await (
                from  users in context.Users
                where users.Id == userId
                select new UserResponseFormat{
                    Id = users.Id,
                    Name = users.Name
                }
            ).FirstOrDefaultAsync();

            return new ResponseModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Discount = product.Discount,
                Price = product.Price,
                Thumb = product.ThumbUrl,
                Tags = categories,
                Images = images,
                Feedbacks = feedbacksSumAndCount.Feedbacks,
                AverageRating = feedbacksSumAndCount.AverageRating,
                Advertiser = advertiser
            };
        }
    }
}