using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cheapy_API.Controllers.ProductController.MyProducts
{
    public class Service
    {
        public async Task<List<ResponseModel>> Execute(AppDbContext context, Guid userId)
        {
            var products = await (
                from product in context.Products
                where product.AdvertiserId == userId
                orderby product.CreatedAt
                select new ResponseModel{
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount,
                    Thumb = product.ThumbUrl
                }
            )
            .AsNoTracking()
            .ToListAsync();

            foreach (var product in products)
            {
                product.Thumb = $"https://localhost:5001/Uploads/{product.Thumb}";

                var feedbacksSumAndCount = await (
                    from feedbacks in context.Feedbacks 
                    where feedbacks.ProductId == product.Id  
                    group feedbacks by feedbacks.ProductId into grp
                    select new 
                    {
                        AverageRating = grp.Average(x => x.Stars)
                    }
                )
                .AsNoTracking()
                .FirstOrDefaultAsync();

                if(feedbacksSumAndCount == null)
                    product.AverageRating = 0.0;
                else
                    product.AverageRating = feedbacksSumAndCount.AverageRating;
            }

            return products;
        }
    }
}