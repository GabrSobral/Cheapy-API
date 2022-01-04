using System.Threading.Tasks;
using System;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Hosting;

namespace Cheapy_API.Controllers.ProductController.Create
{
    public class Service
    {
        public async Task<ResponseModel> Execute(
            AppDbContext context, 
            RequestModel model, 
            Guid userId,
            IWebHostEnvironment webHostEnvironment)
        {
            var thumbPath = new ProccessUpload(webHostEnvironment).Upload(model.Thumb);
            var newProduct = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                Discount = 0,
                AdvertiserId = userId,
                ThumbUrl = thumbPath
            };
            
            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();

            newProduct.ThumbUrl = $"https://localhost:5001/Uploads/{thumbPath}";
            
            return new ResponseModel(newProduct);
        } 
    }
}