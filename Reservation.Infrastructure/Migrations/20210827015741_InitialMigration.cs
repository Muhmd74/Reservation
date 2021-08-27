using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
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
                table: "Trips",
                columns: new[] { "Id", "CityName", "Content", "DateTime", "ImageUrl", "Price", "Title" },
                values: new object[] { new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), "Cairo", "Start and end in Cairo! With the In-depth Cultural tour King Ramses with Cruise - 13 days, you have a 13 days tour package taking you through Cairo, Egypt and 8 other destinations in Egypt. King Ramses with Cruise - 13 days includes accommodation in a hotel as well as an expert guide, meals, transport and more", new DateTime(2021, 8, 27, 3, 57, 38, 563, DateTimeKind.Local).AddTicks(7662), "", 456m, "King Ramses with Cruise - 13 days" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "IsActive", "Name", "Password", "Phone", "UserType" },
                values: new object[,]
                {
                    { new Guid("e755d563-07b6-46c7-8a36-346e11144622"), "Cairo", "admin", true, "Admin", "admin", "01093356547", 1 },
                    { new Guid("e245d563-07b6-46c7-8a36-346e11144376"), "Cairo", "Ahmed43@Icloud.com", true, "Admin", "Ahmed43@Icloud.com", "01022453576", 2 },
                    { new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046"), "Aswan", "mohamed32@yahoo.com", true, "Mohamed Ali", "mohamed32@yahoo.com", "01012489087", 2 },
                    { new Guid("1b26ba12-efd3-4cd0-bf45-2214dcba840b"), "Alexandria", "Mazen12@Yahoo.com", true, "Admin", "Mazen12@Yahoo.com", "01093355434", 2 },
                    { new Guid("e86a2575-8dd3-4ab6-97ce-749aa4da6629"), "Giza", "Ali55@Icloud.com", true, "Admin", "Ali55@Icloud.com", "01094242323", 2 }
                });

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("657180c2-6268-4a7c-a296-959333bd1aa3"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") });

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("7d51f502-875e-44b7-b6bd-2999b7db1f30"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") });

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
        }
    }
}
