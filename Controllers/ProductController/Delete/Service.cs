using System;
using System.Linq;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace Cheapy_API.Controllers.ProductController.Delete
{
    public class Service
    {
        public async Task Execute(
            AppDbContext context, 
            Guid id, 
            string userId,
            IWebHostEnvironment webHostEnvironment)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if(product == null)
                throw new Exception("Product not found status:404");

            if(product.AdvertiserId != userId) 
                throw new Exception("Product is not yours status:400");

            var photos = await context.Photos
                .Where(x => x.ProductId == id)
                .AsNoTracking()
                .ToListAsync();

            ProccessUpload handleFiles = new ProccessUpload(webHostEnvironment);

            foreach(var photo in photos)
                handleFiles.DeleteFile(photo.Url);

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}