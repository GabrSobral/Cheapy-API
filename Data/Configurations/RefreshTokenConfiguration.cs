using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(refreshToken => new { refreshToken.Id });

            #region Relations
                builder
                    .HasOne(refreshToken => refreshToken.User)
                    .WithMany(user => user.RefreshTokens)
                    .HasForeignKey(refreshToken => refreshToken.UserId);
            #endregion
        }
    }
}