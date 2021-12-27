using System.Threading.Tasks;
using System;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ShoppingCartsController.Add
{
    public class Service
    {
        public async Task<ShoppingCart> Execute(
            AppDbContext context, 
            RequestModel model, 
            Guid userId)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == model.ProductId);

            if(product == null)
                throw new Exception("Product not found status:404");

            var alreadYExists = await context.ShoppingCarts
                .FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
        
            if(alreadYExists != null)
            {
                alreadYExists.ProductQuantity = model.Quantity;
                context.ShoppingCarts.Update(alreadYExists);
                await context.SaveChangesAsync();

                return alreadYExists;
            }
                

            var newProduct = new ShoppingCart
            {
                ProductId = model.ProductId,
                UserId = userId,
                ProductQuantity = model.Quantity
            };
            
            await context.ShoppingCarts.AddAsync(newProduct);
            await context.SaveChangesAsync();
            
            return newProduct;
        } 
    }
}