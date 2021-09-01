using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Core.Entities;
using Reservation.Core.Helpers.Category;
using Reservation.Core.Helpers.Trip;

namespace Reservation.Infrastructure.Data.Seed
{
    public class CategoryHelper : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           
            var list = CreateCategory.Category();
            foreach (var category in list)
            {
                builder.HasData(
                    new Category()
                    {
                        Name = category.Name,
                        Id = category.Id,
                        Description = category.Description

                    });
            }
        }
    }
}
