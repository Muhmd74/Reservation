using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;
using Reservation.Core.Helpers.Category;
using Reservation.Core.Helpers.City;

namespace Reservation.Infrastructure.Data.Seed
{
    public class CityHelper
        : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {

            var list = CreateCity.City();
            foreach (var city in list)
            {
                builder.HasData(
                    new City()
                    {
                        Name = city.Name,
                        Id =city.Id,
                        Description = city.Description,
                        CountryId = city.CountryId
                    });
            }
        }
    }
}
