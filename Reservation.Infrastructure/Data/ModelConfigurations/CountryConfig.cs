using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
    public class CountryConfig:IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            //Id
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            //Name
            builder.Property(d => d.Name)
                .HasMaxLength(250);
            builder.Property(d => d.Name)
                .IsRequired();
            builder.HasIndex(d => d.Name)
                .IsUnique();
            //Iso
            builder.Property(d => d.Iso)
                .HasMaxLength(10)
                .IsRequired();
            builder.HasIndex(d => d.Iso)
                .IsUnique();
            //IsDelete
            builder.Property(d => d.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}