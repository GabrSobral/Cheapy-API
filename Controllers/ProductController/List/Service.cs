using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ProductController.List
{
    public class Service
    {
        public async Task<List<ResponseModel>> Execute(AppDbContext context)
        {
            var products = await (
                from product in context.Products
                orderby product.CreatedAt
                select new ResponseModel{
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount,
                    Thumb = product.ThumbUrl
                }
            )
            .AsNoTracking()
            .ToListAsync();

            foreach (var product in products)
            {
                product.Thumb = $"https://localhost:5001/Uploads/{product.Thumb}";
            }

            return products;
        }
    }
}