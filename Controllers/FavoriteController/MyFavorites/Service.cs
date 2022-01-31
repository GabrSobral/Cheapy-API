using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Data;

namespace Cheapy_API.Controllers.FavoriteController.MyFavorites
{
    public class Service
    {
        public async Task<List<ResponseModel>> Execute(AppDbContext context, Guid userId)
        {
            var myFavorites = await (
                from favorites in context.Favorites
                where favorites.UserId == userId
                join product in context.Products
                    on favorites.ProductId equals product.Id
                select new ResponseModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount,
                    Thumb = product.ThumbUrl
                }
            )
            .AsNoTracking()
            .ToListAsync();

            foreach (var product in myFavorites)
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

            return myFavorites;
        }
    }
}