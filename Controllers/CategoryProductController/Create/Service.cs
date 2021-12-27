using System.Threading.Tasks;
using System;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.CategoryProductController.Create
{
    public class Service
    {
        public async Task<Category_Product> Execute(AppDbContext context, RequestModel model)
        {
            var alreadyExists = await context.CategoriesProducts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => 
                    ((x.ProductId == model.Product_Id) && (x.CategoryId == model.Category_id)));

            if(alreadyExists != null)
                throw new Exception("This product already have this category status:400");

            var newProductCatogory = new Category_Product
            {
                ProductId = model.Product_Id,
                CategoryId = model.Category_id
            };
            
            await context.CategoriesProducts.AddAsync(newProductCatogory);
            await context.SaveChangesAsync();

            return newProductCatogory;
        }
    }
}