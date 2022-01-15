using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(orderItem => new { orderItem.ProductId, orderItem.OrderId });
            builder.Property(orderItem => orderItem.Name).IsRequired().HasMaxLength(180);
            builder.Property(orderItem => orderItem.Price).IsRequired();
            builder.Property(orderItem => orderItem.Quantity).IsRequired();

            #region Relations
                builder
                    .HasOne(orderItem => orderItem.Order)
                    .WithMany(order => order.OrderItems)
                    .HasForeignKey(orderItem => orderItem.OrderId);
                builder
                    .HasOne(orderItem => orderItem.Product)
                    .WithMany(product => product.OrderItems)
                    .HasForeignKey(orderItem => orderItem.ProductId);
            #endregion
        }
    }
}