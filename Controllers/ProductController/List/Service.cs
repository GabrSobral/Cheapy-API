using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ProductController.List
{
    public class Service
    {
        public async Task<List<Product>> Execute(AppDbContext context)
        {
            var products = await context.Products
                .AsNoTracking()
                .ToListAsync();

            return products;
        }
    }
}