﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210901212116_CreateTableCountry")]
    partial class CreateTableCountry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reservation.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3cd161b7-3e7a-6914-a8fa-3eba2a8a3f91"),
                            Description = "Book your holiday at one of famous Red Sea resorts like Hurghada, el-Gouna, Makadi bay or even Marsa Alam and combine beach leisure trip with five days Nile ",
                            IsDeleted = false,
                            Name = "Cruise"
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d0f809a-3fb4-4c19-8923-0025ab0e6517"),
                            CountryId = new Guid("13572456-6511-47af-9774-d1055004ce52"),
                            Description = "the beach just in one trip to Egypt.",
                            IsDeleted = false,
                            Name = "Hurghada"
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("Iso")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13572456-6511-47af-9774-d1055004ce52"),
                            Description = "o Egypt to view its ancient monuments, natural attractions beckon travelers too. The Red Sea coast is known for its coral reefs and beach resorts.",
                            IsDeleted = false,
                            Iso = "EG",
                            Name = "Egypt"
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 9, 1, 23, 21, 15, 580, DateTimeKind.Local).AddTicks(2470));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                            CategoryId = new Guid("3cd161b7-3e7a-6914-a8fa-3eba2a8a3f91"),
                            CityId = new Guid("7d0f809a-3fb4-4c19-8923-0025ab0e6517"),
                            Content = "Start and end in Cairo! With the In-depth Cultural tour King Ramses with Cruise - 13 days, you have a 13 days tour package taking you through Cairo, Egypt and 8 other destinations in Egypt. King Ramses with Cruise - 13 days includes accommodation in a hotel as well as an expert guide, meals, transport and more",
                            DateTime = new DateTime(2021, 9, 1, 23, 21, 15, 508, DateTimeKind.Local).AddTicks(4462),
                            ImageUrl = "",
                            IsDeleted = false,
                            Price = 456m,
                            Title = "King Ramses with Cruise - 13 days"
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.TripUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.HasIndex("UserId");

                    b.ToTable("TripUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a28db0bf-1c5f-4cf4-86a2-6264c18a0677"),
                            TripId = new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                            UserId = new Guid("e245d563-07b6-46c7-8a36-346e11144376")
                        },
                        new
                        {
                            Id = new Guid("f3960e49-d744-43be-aaf7-2aea0514cf4a"),
                            TripId = new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                            UserId = new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046")
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e755d563-07b6-46c7-8a36-346e11144622"),
                            Address = "Cairo",
                            Email = "admin",
                            IsActive = true,
                            Name = "Admin",
                            Password = "admin",
                            Phone = "01093356547",
                            UserType = 1
                        },
                        new
                        {
                            Id = new Guid("e245d563-07b6-46c7-8a36-346e11144376"),
                            Address = "Cairo",
                            Email = "Ahmed43@Icloud.com",
                            IsActive = true,
                            Name = "Ahmed Magdy",
                            Password = "Ahmed43@Icloud.com",
                            Phone = "01022453576",
                            UserType = 2
                        },
                        new
                        {
                            Id = new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046"),
                            Address = "Aswan",
                            Email = "mohamed32@yahoo.com",
                            IsActive = true,
                            Name = "Mohamed Ali",
                            Password = "mohamed32@yahoo.com",
                            Phone = "01012489087",
                            UserType = 2
                        },
                        new
                        {
                            Id = new Guid("1b26ba12-efd3-4cd0-bf45-2214dcba840b"),
                            Address = "Alexandria",
                            Email = "Mazen12@Yahoo.com",
                            IsActive = true,
                            Name = "Mazen",
                            Password = "Mazen12@Yahoo.com",
                            Phone = "01093355434",
                            UserType = 2
                        },
                        new
                        {
                            Id = new Guid("e86a2575-8dd3-4ab6-97ce-749aa4da6629"),
                            Address = "Giza",
                            Email = "Ali55@Icloud.com",
                            IsActive = true,
                            Name = "Ali Mohamed",
                            Password = "Ali55@Icloud.com",
                            Phone = "01094242323",
                            UserType = 2
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.City", b =>
                {
                    b.HasOne("Reservation.Core.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Trip", b =>
                {
                    b.HasOne("Reservation.Core.Entities.Category", "Category")
                        .WithMany("Trips")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservation.Core.Entities.City", "City")
                        .WithMany("Trips")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Reservation.Core.Entities.TripUser", b =>
                {
                    b.HasOne("Reservation.Core.Entities.Trip", "Trip")
                        .WithMany("TripUsers")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Reservation.Core.Entities.User", "User")
                        .WithMany("TripUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Category", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Reservation.Core.Entities.City", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Trip", b =>
                {
                    b.Navigation("TripUsers");
                });

            modelBuilder.Entity("Reservation.Core.Entities.User", b =>
                {
                    b.Navigation("TripUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
