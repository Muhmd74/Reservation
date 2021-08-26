using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;
using Reservation.Core.Helpers.TripUser;

namespace Reservation.Infrastructure.Data.Seed
{
    public class TripUserHelper : IEntityTypeConfiguration<TripUser>
    {
        public void Configure(EntityTypeBuilder<TripUser> builder)
        {
            var list = CreateTripUser.TripUser();
            foreach (var tripUser in list)
            {
                builder.HasData(
                    new TripUser()
                    {
                        TripId = tripUser.TripId,
                        UserId = tripUser.UserId,
                        Id = Guid.NewGuid()
                    });
            }
        }
    }
}
