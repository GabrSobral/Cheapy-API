using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.CategoryProductController.ShowFromProduct
{
    public class Service
    {
        public async Task<List<Category>> Execute(AppDbContext context, Guid productId)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
                throw new Exception("Product not found status:400");

            var categories = await context.CategoriesProducts.Join(
                context.Categories,
                cp => cp.CategoryId,
                c => c.Id,
                (cp, c) => new Category {
                    Id = c.Id,
                    Name = c.Name,
                }
            )
            .AsNoTracking()
            .ToListAsync();

            return categories;
        }
    }
}