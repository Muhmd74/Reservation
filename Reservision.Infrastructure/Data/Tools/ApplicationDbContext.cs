using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RegisterUsers.Core.Models;

namespace RegisterUser.Infrastructure.Data.Tools
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionOptions.Create(), x => x.MigrationsHistoryTable("Assembly"));
            base.OnConfiguring(optionsBuilder);
        }

        //Users
        public DbSet<User> Users { get; set; }
        //Trips
        public DbSet<Trip> Trips { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
