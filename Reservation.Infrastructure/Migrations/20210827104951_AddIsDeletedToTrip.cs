using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Infrastructure.Migrations
{
    public partial class AddIsDeletedToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("657180c2-6268-4a7c-a296-959333bd1aa3"));

            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("7d51f502-875e-44b7-b6bd-2999b7db1f30"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Trips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e5d45e31-e049-4240-86a9-8f1af8ccb8e6"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") },
                    { new Guid("85d69b68-5fd5-4c33-8917-5e25729725b1"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") }
                });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                column: "DateTime",
                value: new DateTime(2021, 8, 27, 12, 49, 49, 701, DateTimeKind.Local).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b26ba12-efd3-4cd0-bf45-2214dcba840b"),
                column: "Name",
                value: "Mazen");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e245d563-07b6-46c7-8a36-346e11144376"),
                column: "Name",
                value: "Ahmed Magdy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e86a2575-8dd3-4ab6-97ce-749aa4da6629"),
                column: "Name",
                value: "Ali Mohamed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("85d69b68-5fd5-4c33-8917-5e25729725b1"));

            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5d45e31-e049-4240-86a9-8f1af8ccb8e6"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Trips");

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[,]
                {
                    { new Guid("657180c2-6268-4a7c-a296-959333bd1aa3"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") },
                    { new Guid("7d51f502-875e-44b7-b6bd-2999b7db1f30"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") }
                });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                column: "DateTime",
                value: new DateTime(2021, 8, 27, 3, 57, 38, 563, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b26ba12-efd3-4cd0-bf45-2214dcba840b"),
                column: "Name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e245d563-07b6-46c7-8a36-346e11144376"),
                column: "Name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e86a2575-8dd3-4ab6-97ce-749aa4da6629"),
                column: "Name",
                value: "Admin");
        }
    }
}
