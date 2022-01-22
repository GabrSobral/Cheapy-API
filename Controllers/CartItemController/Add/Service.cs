using System.Threading.Tasks;
using System;
using System.Linq;
using Cheapy_API.Data;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.ShoppingCartsController.Add
{
    public class Service
    {
        public async Task<dynamic> Execute(
            AppDbContext context, 
            RequestModel model, 
            Guid userId)
        {
            if(model.Quantity <= 0)
                throw new Exception("Quantity cannot be equal 0 status:400");

            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == model.ProductId);

            if(product == null)
                throw new Exception("Product not found status:400");

            var alreadYExists = await context.CartItems
                .FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
        
            if(alreadYExists != null)
            {
                alreadYExists.ProductQuantity = model.Quantity;
                context.CartItems.Update(alreadYExists);
                await context.SaveChangesAsync();
                return alreadYExists;
            }

            var newProduct = new CartItem
            {
                ProductId = model.ProductId,
                UserId = userId,
                ProductQuantity = model.Quantity
            };
            
            await context.CartItems.AddAsync(newProduct);
            await context.SaveChangesAsync();
            
            return newProduct;
        } 
    }
}