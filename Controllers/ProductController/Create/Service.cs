using System.Threading.Tasks;
using System.Linq;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Cheapy_API.Controllers.ProductController.Create
{
    public class Service
    {
        public async Task<ResponseModel> Execute(
            AppDbContext context, 
            RequestModel model, 
            string userId,
            IWebHostEnvironment webHostEnvironment)
        {
            var thumbPath = new ProccessUpload(webHostEnvironment).Upload(model.Thumb);

            if(userId == null)
                throw new Exception("User not found status:400");

            var newProduct = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
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