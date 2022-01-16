using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.CartItemController.MyList
{
    public class Service
    {
        public async Task<List<ResponseModel>> Execute(AppDbContext context, string userId)
        {
            var myCartItems = await (
                from cartItem in context.CartItems
                where cartItem.UserId == userId
                join product in context.Products
                    on cartItem.ProductId equals product.Id
                select new ResponseModel{
                    Id = product.Id,
                    Name = product.Name,
                    Thumb = product.ThumbUrl,
                    Quantity = cartItem.ProductQuantity,
                }
            )
            .AsNoTracking()
            .ToListAsync();
            
            return myCartItems;
        } 
    }
}