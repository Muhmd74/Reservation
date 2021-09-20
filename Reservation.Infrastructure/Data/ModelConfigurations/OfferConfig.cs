using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
    public class OfferConfig : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            //Id
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            //Name
            builder.Property(d => d.Title)
                .HasMaxLength(250);
            builder.Property(d => d.Title)
                .IsRequired();
            builder.HasOne(d => d.Trip)
                .WithMany(d => d.Offers)
                .IsRequired()
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
