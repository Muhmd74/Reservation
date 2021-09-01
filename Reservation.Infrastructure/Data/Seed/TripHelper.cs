using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;
using Reservation.Core.Helpers.Trip;
using Reservation.Core.Helpers.User;

namespace Reservation.Infrastructure.Data.Seed
{
    public class TripHelper : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            var list = CreateTrip.Trip();
            foreach (var trip in list)
            {
                builder.HasData(
                    new Trip()
                    {
                        CityId = trip.CityId,
                        CategoryId = trip.CategoryId,
                        Content = trip.Content,
                        DateTime = DateTime.Now,
                        Price = trip.Price,
                        Title = trip.Title,
                        Id = trip.Id,
                        ImageUrl = trip.ImageUrl
                    });
            }
        }
    }
}
