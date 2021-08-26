using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Infrastructure.Migrations
{
    public partial class CreateTripUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TripUser",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("af1fd978-e084-4152-8880-87d3787e6c7e"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") });

            migrationBuilder.InsertData(
                table: "TripUser",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("59ee1642-34be-45ec-a4ac-616143ae703c"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                column: "DateTime",
                value: new DateTime(2021, 8, 26, 5, 27, 45, 182, DateTimeKind.Local).AddTicks(8381));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripUser",
                keyColumn: "Id",
                keyValue: new Guid("59ee1642-34be-45ec-a4ac-616143ae703c"));

            migrationBuilder.DeleteData(
                table: "TripUser",
                keyColumn: "Id",
                keyValue: new Guid("af1fd978-e084-4152-8880-87d3787e6c7e"));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                column: "DateTime",
                value: new DateTime(2021, 8, 26, 5, 17, 0, 250, DateTimeKind.Local).AddTicks(2454));
        }
    }
}
