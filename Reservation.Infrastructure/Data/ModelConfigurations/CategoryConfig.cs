using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
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

            builder.HasMany(d => d.Trips)
                .WithOne(d => d.Category)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

