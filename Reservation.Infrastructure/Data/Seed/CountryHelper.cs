using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;
using Reservation.Core.Helpers.City;
using Reservation.Core.Helpers.Country;

namespace Reservation.Infrastructure.Data.Seed
{
    public class CountryHelper : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {

            var list = CreateCountry.Country();
            foreach (var country in list)
            {
                builder.HasData(
                    new Country()
                    {
                        Name = country.Name,
                        Id = country.Id,
                        Description = country.Description,
                        Iso = country.Iso

                    });
            }
        }
    }
}
