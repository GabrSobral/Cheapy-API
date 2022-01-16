using System.Threading.Tasks;
using System;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ProductTagController.Delete
{
    public class Service
    {
        public async Task Execute(AppDbContext context, RequestModel model)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == model.Product_Id);

            if(product == null)
                throw new Exception("Product not found status:404");

            var tag = await context.ProductTags
                .FirstOrDefaultAsync(x => (x.ProductId == model.Product_Id) && (x.Name == model.Name.ToLower()));
      
            context.ProductTags.Remove(tag);
            await context.SaveChangesAsync();
        }
    }
}