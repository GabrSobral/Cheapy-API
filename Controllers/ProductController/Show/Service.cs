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
        public async Task<ResponseModel> Execute(AppDbContext context, Guid productId)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:400");
            
            var tags = await context.ProductTags
                .Where(x => x.ProductId == productId)
                .Select(x => new TagFormat{ 
                    Id = x.Id, 
                    Name = x.Name 
                })
                .AsNoTracking()
                .ToListAsync();
            
            var images = await context.Photos
                .Where(x => x.ProductId == productId)
                .Select(x => new ImageFormat{ 
                    Id = x.Id, 
                    Url = $"https://localhost:5001/Uploads/{x.Url}" 
                })
                .AsNoTracking()
                .ToListAsync();

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

            if(feedbacksSumAndCount == null)
            {
                feedbacksSumAndCount = new 
                {
                    Feedbacks = 0,
                    AverageRating = 0.0
                };
            }

            var advertiser = await (
                from  users in context.Users
                where users.Id == product.AdvertiserId
                select new UserFormat {
                    Id = users.Id,
                    Name = users.Name
                }
            )
            .AsNoTracking()
            .FirstOrDefaultAsync();

            return new ResponseModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Discount = product.Discount,
                Price = product.Price,
                Thumb = $"https://localhost:5001/Uploads/{product.ThumbUrl}",
                Tags = tags,
                Images = images,
                Feedbacks = feedbacksSumAndCount.Feedbacks,
                AverageRating = feedbacksSumAndCount.AverageRating,
                Advertiser = advertiser
            };
        }
    }
}