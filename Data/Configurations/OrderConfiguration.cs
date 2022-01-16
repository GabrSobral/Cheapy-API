using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.Property(order => order.Status).IsRequired();
            builder.Property(order => order.UserId).IsRequired();
            builder.Property(order => order.UserEmail).IsRequired();
            builder.Property(order => order.Country).IsRequired();
            builder.Property(order => order.PostalCode).IsRequired();
            builder.Property(order => order.ShipPostalCode).IsRequired();
            builder.Property(order => order.AdvertiserId).IsRequired();
            builder.Property(order => order.PaymentProvider).IsRequired();

            #region Relations
                builder
                    .HasOne(order => order.User)
                    .WithMany(user => user.OrdersByUser)
                    .HasForeignKey(order => order.UserId);

                builder
                    .HasOne(order => order.Advertiser)
                    .WithMany(user => user.OrdersByAdvertiser)
                    .HasForeignKey(order => order.AdvertiserId);
            #endregion
        }
    }
}