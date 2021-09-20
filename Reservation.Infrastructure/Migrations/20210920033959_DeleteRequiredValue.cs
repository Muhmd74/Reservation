using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Infrastructure.Migrations
{
    public partial class DeleteRequiredValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Firms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 5, 39, 56, 683, DateTimeKind.Local).AddTicks(2084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 4, 36, 47, 63, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13572456-6511-47af-9774-d1055004ce52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afceee69-2841-4582-a68e-3c99f79112da", "AQAAAAEAACcQAAAAEGfsAFJwF5Et72cUUSZxDn+G8bi+lNEZOyIDmHga60XACNEdO6qonjIUAxSoy0cKzQ==", "90088432-3091-4fe0-9d03-23027087a664" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 4, 36, 47, 63, DateTimeKind.Local).AddTicks(2489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 5, 39, 56, 683, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Firms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13572456-6511-47af-9774-d1055004ce52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99d32720-510c-481b-986b-afc5c47e9906", "AQAAAAEAACcQAAAAEPbMZEyrJmYFMEtps6zlNMH+6vAJlJJmabv6LOdqjdOcttR9UIlpR6eDuKN8v7F0xQ==", "135ece5f-3461-401a-a179-a57ea8e06e93" });
        }
    }
}
