using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ProductController.Delete
{
    public class Service
    {
        public async Task Execute(AppDbContext context, Guid id, Guid userId)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if(product == null)
                throw new Exception("Product not found status:404");

            if(product.AdvertiserId != userId) 
                throw new Exception("Product is not yours status:400");
            
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}