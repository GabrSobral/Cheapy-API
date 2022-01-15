using System;
using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Email);

            builder.Property(user => user.Id).IsRequired().HasMaxLength(12);
            builder.Property(user => user.Name).IsRequired().HasMaxLength(80);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(80);
            builder.Property(user => user.PostalCode).IsRequired().HasMaxLength(11);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(80);
            builder.Property(user => user.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            #region Relations
                builder.HasMany(user => user.OrdersByUser).WithOne(order => order.User);
                builder.HasMany(user => user.OrdersByAdvertiser).WithOne(order => order.Advertiser);
                builder.HasMany(user => user.CartItems).WithOne(cartItem => cartItem.User);
                builder.HasMany(user => user.Feedbacks).WithOne(feedback => feedback.User);
                builder.HasMany(user => user.Products).WithOne(product => product.Advertiser);
            #endregion
        }
    }
}