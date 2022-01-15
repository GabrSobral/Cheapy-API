using Cheapy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cheapy_API.Data.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(feeedback => new { feeedback.ProductId, feeedback.UserId });

            builder.Property(feedback => feedback.Title).IsRequired().HasMaxLength(80);
            builder.Property(feedback => feedback.Message).IsRequired().HasMaxLength(240);
            builder.Property(feedback => feedback.Stars).IsRequired();
            builder.Property(feedback => feedback.Recomendation).IsRequired();

            #region Relations
                builder
                    .HasOne(feedback => feedback.User)
                    .WithMany(user => user.Feedbacks)
                    .HasForeignKey(feedback => feedback.UserId);

                builder
                    .HasOne(feedback => feedback.Product)
                    .WithMany(product => product.Feedbacks)
                    .HasForeignKey(feedback => feedback.ProductId);
            #endregion
        }
    }
}