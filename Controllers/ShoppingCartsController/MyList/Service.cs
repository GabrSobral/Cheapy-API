using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ShoppingCartsController.MyList
{
    public class Service
    {
        public async Task<List<ResponseModel>> Execute(AppDbContext context, Guid userId)
        {
            var myShoppingCarts = await context.ShoppingCarts
                .Join(
                    context.Products,
                    sc => sc.ProductId,
                    p => p.Id,
                    (sc, p) => new ResponseModel{
                        Product = p,
                        Quantity = sc.ProductQuantity
                    }
                )
                .AsNoTracking()
                .ToListAsync();
            
            return myShoppingCarts;
        } 
    }
}