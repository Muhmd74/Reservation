using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Infrastructure.Migrations
{
    public partial class CreateTableCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Category_CategoryId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_City_CityId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("70a1f098-601d-4026-a7f2-dd1f7368be20"));

            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("8af15f53-6531-49fc-8893-775d14d8dbd7"));

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Country_Name",
                table: "Countries",
                newName: "IX_Countries_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Country_Iso",
                table: "Countries",
                newName: "IX_Countries_Iso");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 1, 23, 21, 15, 580, DateTimeKind.Local).AddTicks(2470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 1, 20, 51, 42, 878, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("a28db0bf-1c5f-4cf4-86a2-6264c18a0677"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") });

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("f3960e49-d744-43be-aaf7-2aea0514cf4a"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                column: "DateTime",
                value: new DateTime(2021, 9, 1, 23, 21, 15, 508, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Categories_CategoryId",
                table: "Trips",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Categories_CategoryId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("a28db0bf-1c5f-4cf4-86a2-6264c18a0677"));

            migrationBuilder.DeleteData(
                table: "TripUsers",
                keyColumn: "Id",
                keyValue: new Guid("f3960e49-d744-43be-aaf7-2aea0514cf4a"));

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_Name",
                table: "Country",
                newName: "IX_Country_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_Iso",
                table: "Country",
                newName: "IX_Country_Iso");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "City",
                newName: "IX_City_CountryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 1, 20, 51, 42, 878, DateTimeKind.Local).AddTicks(7783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 1, 23, 21, 15, 580, DateTimeKind.Local).AddTicks(2470));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("70a1f098-601d-4026-a7f2-dd1f7368be20"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("e245d563-07b6-46c7-8a36-346e11144376") });

            migrationBuilder.InsertData(
                table: "TripUsers",
                columns: new[] { "Id", "TripId", "UserId" },
                values: new object[] { new Guid("8af15f53-6531-49fc-8893-775d14d8dbd7"), new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"), new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046") });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                column: "DateTime",
                value: new DateTime(2021, 9, 1, 20, 51, 42, 516, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Category_CategoryId",
                table: "Trips",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_City_CityId",
                table: "Trips",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
