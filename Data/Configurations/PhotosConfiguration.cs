using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class PhotosConfiguration : IEntityTypeConfiguration<Photos>
    {
         public void Configure(EntityTypeBuilder<Photos> builder)
        {
            builder.HasKey(photo => photo.Id);
            builder.Property(photo => photo.Url).IsRequired();
            builder.Property(photo => photo.ProductId).IsRequired();

            #region Relations
                builder
                    .HasOne(photo => photo.Product)
                    .WithMany(product => product.Photos)
                    .HasForeignKey(photo => photo.ProductId);
            #endregion
        }
    }
}