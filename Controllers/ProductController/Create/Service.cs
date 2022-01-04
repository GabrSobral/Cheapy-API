using System.Threading.Tasks;
using System;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ProductController.Create
{
    public class Service
    {
        public async Task<ResponseModel> Execute(AppDbContext context, RequestModel model, Guid userId)
        {
            var newProduct = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                Discount = 0,
                AdvertiserId = userId,
                ThumbUrl = model.Thumb
            };
            
            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();
            
            return new ResponseModel(newProduct);
        } 
    }
}