using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(d => d.Id)
                .HasDefaultValueSql("NEWID()");

            //Email
            builder.Property(d => d.Email)
                .HasMaxLength(250)
                .IsRequired();
            builder.HasIndex(d => d.Email)
                .IsUnique();
            //Password
            builder.Property(d => d.Password)
                .HasMaxLength(250)
                .IsRequired();
            //IsActive
            builder.Property(d => d.IsActive)
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
