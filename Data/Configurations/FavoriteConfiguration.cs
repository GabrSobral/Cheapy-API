using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.UserId });

            #region Relations
                builder.HasOne(x => x.User).WithMany(user => user.Favorites);
                builder.HasOne(x => x.Product).WithMany(product => product.Favorites);
            #endregion
        }
    }
}