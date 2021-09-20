using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
    public class FirmConfig : IEntityTypeConfiguration<Firm>
    {
        public void Configure(EntityTypeBuilder<Firm> builder)
        {
            //Id
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            //Name
            builder.Property(d => d.Name)
                .HasMaxLength(250);
            builder.Property(d => d.Name)
                .IsRequired();
            //IsDelete
            builder.Property(d => d.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(d => d.Email)
                .IsRequired();
            builder.HasIndex(d => d.Email)
                .IsUnique();
            //Mobile
            builder.Property(d => d.Mobile)
                .IsRequired();
            builder.HasIndex(d => d.Mobile)
                .IsUnique();
            //LandLine
            builder.Property(d => d.Landline)
                .IsRequired();
            builder.HasIndex(d => d.Landline)
                .IsUnique();
            //Firm : Trip
            builder.HasMany(d => d.Trips)
                .WithOne(d => d.Firm)
                 .HasForeignKey(d => d.FirmId)
                .OnDelete(DeleteBehavior.NoAction);
            //Firm : User
            builder.HasMany(d => d.User)
                .WithOne(d => d.Firm)
                 .HasForeignKey(d => d.FirmId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
