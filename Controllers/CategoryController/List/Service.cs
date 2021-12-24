using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.CategoryController.List
{
    public class Service
    {
        public async Task<List<Category>> Execute(AppDbContext context)
        {
            var categories = await context.Categories
                .AsNoTracking()
                .ToListAsync();

            return categories;
        }
    }
}