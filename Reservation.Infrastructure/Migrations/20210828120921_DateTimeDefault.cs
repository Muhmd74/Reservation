using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Infrastructure.Migrations
{
    public partial class DateTimeDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d69b68-5fd5-4c33-8917-5e25729725b1"));

            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5d45e31-e049-4240-86a9-8f1af8ccb8e6"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 28, 14, 9, 19, 242, DateTimeKind.Local).AddTicks(8017),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("bc5003f5-b3fb-42e6-a67f-80bb1cd2cf93"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") });

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("d3d28dd0-275b-4f48-a600-dba394b78dea"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                column: "DateTime",
                value: new DateTime(2021, 8, 28, 14, 9, 19, 213, DateTimeKind.Local).AddTicks(1496));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc5003f5-b3fb-42e6-a67f-80bb1cd2cf93"));

            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("d3d28dd0-275b-4f48-a600-dba394b78dea"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 28, 14, 9, 19, 242, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("e5d45e31-e049-4240-86a9-8f1af8ccb8e6"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") });

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("85d69b68-5fd5-4c33-8917-5e25729725b1"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                column: "DateTime",
                value: new DateTime(2021, 8, 27, 12, 49, 49, 701, DateTimeKind.Local).AddTicks(8805));
        }
    }
}
