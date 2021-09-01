using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 1, 20, 51, 42, 878, DateTimeKind.Local).AddTicks(7783)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TripId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripUsers_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("3cd161b7-3e7a-6914-a8fa-3eba2a8a3f91"), "Book your holiday at one of famous Red Sea resorts like Hurghada, el-Gouna, Makadi bay or even Marsa Alam and combine beach leisure trip with five days Nile ", "Cruise" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Description", "Iso", "Name" },
                values: new object[] { new Guid("13572456-6511-47af-9774-d1055004ce52"), "o Egypt to view its ancient monuments, natural attractions beckon travelers too. The Red Sea coast is known for its coral reefs and beach resorts.", "EG", "Egypt" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "IsActive", "Name", "Password", "Phone", "UserType" },
                values: new object[,]
                {
                    { new Guid("e755d563-07b6-46c7-8a36-346e11144622"), "Cairo", "admin", true, "Admin", "admin", "01093356547", 1 },
                    { new Guid("e245d563-07b6-46c7-8a36-346e11144376"), "Cairo", "Ahmed43@Icloud.com", true, "Ahmed Magdy", "Ahmed43@Icloud.com", "01022453576", 2 },
                    { new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046"), "Aswan", "mohamed32@yahoo.com", true, "Mohamed Ali", "mohamed32@yahoo.com", "01012489087", 2 },
                    { new Guid("1b26ba12-efd3-4cd0-bf45-2214dcba840b"), "Alexandria", "Mazen12@Yahoo.com", true, "Mazen", "Mazen12@Yahoo.com", "01093355434", 2 },
                    { new Guid("e86a2575-8dd3-4ab6-97ce-749aa4da6629"), "Giza", "Ali55@Icloud.com", true, "Ali Mohamed", "Ali55@Icloud.com", "01094242323", 2 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Description", "Name" },
                values: new object[] { new Guid("7d0f809a-3fb4-4c19-8923-0025ab0e6517"), new Guid("13572456-6511-47af-9774-d1055004ce52"), "the beach just in one trip to Egypt.", "Hurghada" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CategoryId", "CityId", "Content", "DateTime", "ImageUrl", "IsDeleted", "Price", "Title" },
                values: new object[] { new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("3cd161b7-3e7a-6914-a8fa-3eba2a8a3f91"), new Guid("7d0f809a-3fb4-4c19-8923-0025ab0e6517"), "Start and end in Cairo! With the In-depth Cultural tour King Ramses with Cruise - 13 days, you have a 13 days tour package taking you through Cairo, Egypt and 8 other destinations in Egypt. King Ramses with Cruise - 13 days includes accommodation in a hotel as well as an expert guide, meals, transport and more", new DateTime(2021, 9, 1, 20, 51, 42, 516, DateTimeKind.Local).AddTicks(5674), "", false, 456m, "King Ramses with Cruise - 13 days" });

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("70a1f098-601d-4026-a7f2-dd1f7368be20"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") });

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("8af15f53-6531-49fc-8893-775d14d8dbd7"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Iso",
                table: "Country",
                column: "Iso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CategoryId",
                table: "Trips",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CityId",
                table: "Trips",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TripUsers_TripId",
                table: "TripUsers",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripUsers_UserId",
                table: "TripUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripUsers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
