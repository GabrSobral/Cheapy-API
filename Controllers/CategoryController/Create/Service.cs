using System.Threading.Tasks;
using System;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.CategoryController.Create
{
    public class Service
    {
        public async Task<ResponseModel> Execute(AppDbContext context, RequestModel model)
        {
            var alreadyExists = await context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == model.Name);

            if(alreadyExists != null)
                throw new Exception("Category already exists status:400");

            var category = new Category
            {
                Name = model.Name
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return new ResponseModel(category);
        }
    }
}