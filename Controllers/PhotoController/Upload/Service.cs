using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.PhotoController.Upload
{
    public class Service
    {
        public async Task<Photos> Execute(
            AppDbContext context, 
            RequestModel model,
            IWebHostEnvironment webHostEnviroment,
            Guid productId)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:400");
                
            string fileName = new ProccessUpload(webHostEnviroment).Upload(model.Photo);

            var newPhoto = new  Photos
            {
                Url = fileName,
                ProductId = productId
            };

            await context.Photos.AddAsync(newPhoto);
            await context.SaveChangesAsync();

            return newPhoto;
        }
    }
}