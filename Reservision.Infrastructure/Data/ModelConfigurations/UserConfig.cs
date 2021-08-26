using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegisterUsers.Core.Models;

namespace RegisterUser.Infrastructure.Data.ModelConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            //Email
            builder.Property(x => x.Email)
                .HasMaxLength(250)
                .IsRequired();
            builder.HasIndex(x => x.Email)
                .IsUnique();
            //Password
            builder.Property(d => d.Password)
                .HasMaxLength(250)
                .IsRequired();
            //IsActive
            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);
            //Name
            builder.Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired();
            //Phone
            builder.Property(d => d.Phone)
                .HasMaxLength(250);


        }
    }
}
