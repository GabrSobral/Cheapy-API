using System.Threading.Tasks;
using System;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ProductTagController.Create
{
    public class Service
    {
        public async Task<Product_Tags> Execute(AppDbContext context, RequestModel model)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == model.Product_Id);

            if(product == null)
                throw new Exception("Product not found status:404");

            var alreadyExists = await context.ProductTags
                .AsNoTracking()
                .FirstOrDefaultAsync(x => 
                    ((x.ProductId == model.Product_Id) && (x.Name == model.Name.ToLower())));

            if(alreadyExists != null)
                throw new Exception("This product already have this category status:400");

            var newProductCatogory = new Product_Tags
            {
                ProductId = model.Product_Id,
                Name = model.Name.ToLower()
            };
            
            await context.ProductTags.AddAsync(newProductCatogory);
            await context.SaveChangesAsync();

            return newProductCatogory;
        }
    }
}