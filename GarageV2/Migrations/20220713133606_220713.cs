using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageV2.Migrations
{
    public partial class _220713 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "abb456",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 13, 15, 21, 6, 752, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "abc123",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 13, 15, 26, 6, 752, DateTimeKind.Local).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "krtekl",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 13, 15, 36, 6, 752, DateTimeKind.Local).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "MyBike",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 13, 14, 36, 6, 752, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "oPq144",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 13, 15, 34, 6, 752, DateTimeKind.Local).AddTicks(6234));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "abb456",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 12, 9, 10, 26, 754, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "abc123",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 12, 9, 15, 26, 754, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "krtekl",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 12, 9, 25, 26, 754, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "MyBike",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 12, 8, 25, 26, 754, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "oPq144",
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 12, 9, 23, 26, 754, DateTimeKind.Local).AddTicks(1293));
        }
    }
}
