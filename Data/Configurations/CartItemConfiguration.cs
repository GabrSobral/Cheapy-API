using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(cartItem => new { cartItem.ProductId, cartItem.UserId });
            builder.Property(cartItem => cartItem.ProductQuantity).IsRequired();

            #region Relations
                builder
                    .HasOne(cartItem => cartItem.User)
                    .WithMany(user => user.CartItems)
                    .HasForeignKey(cartItem => cartItem.UserId);
                    
                builder
                    .HasOne(cartItem => cartItem.Product)
                    .WithMany(product => product.CartItems)
                    .HasForeignKey(cartItem => cartItem.ProductId);
            #endregion
        }
    }
}