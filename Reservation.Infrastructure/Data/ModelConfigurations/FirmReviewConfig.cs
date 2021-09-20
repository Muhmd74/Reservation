using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
    public class FirmReviewConfig : IEntityTypeConfiguration<FirmReview>
    {
        public void Configure(EntityTypeBuilder<FirmReview> builder)
        {
            //Id
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            //Name
            builder.Property(d => d.Comment)
                .HasMaxLength(250);
            builder.Property(d => d.Comment)
                .IsRequired();
            builder.HasOne(d => d.User)
                .WithMany(d => d.FirmReviews)
                .HasForeignKey(d => d.UserId);

        }
    }
}
