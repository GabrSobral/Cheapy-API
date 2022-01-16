using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Name).IsRequired().HasMaxLength(180);
            builder.Property(product => product.Description).IsRequired();
            builder.Property(product => product.Discount).IsRequired();
            builder.Property(product => product.Stock).IsRequired();
            builder.Property(product => product.ThumbUrl).IsRequired();
            builder.Property(product => product.Price).IsRequired().HasPrecision(8,2);

            #region Relations
                builder
                    .HasOne(product => product.Advertiser)
                    .WithMany(user => user.Products)
                    .HasForeignKey(produdct => produdct.AdvertiserId);
                    
                builder.HasMany(product => product.Photos).WithOne(photos => photos.Product);
                builder.HasMany(product => product.CartItems).WithOne(cartItem => cartItem.Product);
                builder.HasMany(product => product.Feedbacks).WithOne(feedbacks => feedbacks.Product);
                builder.HasMany(product => product.OrderItems).WithOne(orderItems => orderItems.Product);
                builder.HasMany(product => product.ProductTags).WithOne(productTags => productTags.Product);
            #endregion
        }        
    }
}