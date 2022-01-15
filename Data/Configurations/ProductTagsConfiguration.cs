using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class ProductTagsConfiguration : IEntityTypeConfiguration<Product_Tags>
    {
        public void Configure(EntityTypeBuilder<Product_Tags> builder)
        {
            builder.HasKey(productTags => productTags.ProductId);
            builder.Property(productTags => productTags.Name).IsRequired().HasMaxLength(30);

            #region Relations
                builder
                    .HasOne(productTag => productTag.Product)
                    .WithMany(product => product.ProductTags)
                    .HasForeignKey(productTags => productTags.ProductId);
            #endregion
        }
    }
}