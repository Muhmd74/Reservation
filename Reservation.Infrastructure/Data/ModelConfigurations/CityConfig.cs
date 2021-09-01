using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data.ModelConfigurations
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
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
             //City : Country
             builder.HasOne(d => d.Country)
                 .WithMany(d => d.Cities)
                 .HasForeignKey(d => d.CountryId)
                 .OnDelete(DeleteBehavior.Cascade);
             //City : trip
            builder.HasMany(d => d.Trips)
                 .WithOne(d => d.City)
                 .HasForeignKey(d => d.CityId)
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}