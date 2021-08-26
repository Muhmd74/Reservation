using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
   public class TripUserConfig : IEntityTypeConfiguration<TripUser>
    {
        public void Configure(EntityTypeBuilder<TripUser> builder)
        {
            //Id
            builder.Property(d => d.Id)
                .HasDefaultValueSql("NEWID()");

            //TripUsers => Trip
            builder.HasOne(d => d.Trip)
                .WithMany(d => d.TripUsers)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.NoAction);

            //TripUsers => Trip
            builder.HasOne(d => d.User)
                .WithMany(d => d.TripUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
