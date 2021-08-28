using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
   public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            //Id
            builder.Property(d  => d .Id)
                .HasDefaultValueSql("NEWID()");
            //CityName
            builder.Property(d => d.CityName)
                .HasMaxLength(250);
            //Title
            builder.Property(d => d.Title)
                .HasMaxLength(200);
            builder.Property(d => d.DateTime)
                .HasDefaultValue(DateTime.Now);

        }
    }
}
