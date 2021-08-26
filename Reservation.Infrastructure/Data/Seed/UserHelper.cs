using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;
using Reservation.Core.Helpers.User;

namespace Reservation.Infrastructure.Data.Seed
{
    public class UserHelper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var list = CreateUser.User();
            foreach (var user in list)
            {
                builder.HasData(
                    new User
                    {
                        Name = user.Name,
                        Password = user.Password,
                        Address = user.Address,
                        Email = user.Email,
                        IsActive = true,
                        Phone = user.Phone,
                        UserType = user.UserType,
                        Id = user.Id
                    });
            }
        }
    }
}
