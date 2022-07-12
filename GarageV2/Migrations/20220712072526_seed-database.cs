using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageV2.Migrations
{
    public partial class seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "RegNr", "ArrivalTime", "Brand", "Color", "Model", "VehicleType", "Wheels" },
                values: new object[,]
                {
                    { "abb456", new DateTime(2022, 7, 12, 9, 10, 26, 754, DateTimeKind.Local).AddTicks(1290), "Saab", "Grön", "99", "PersonBil", 4 },
                    { "abc123", new DateTime(2022, 7, 12, 9, 15, 26, 754, DateTimeKind.Local).AddTicks(1252), "Volvo", "Röd", "X90", "PersonBil", 4 },
                    { "krtekl", new DateTime(2022, 7, 12, 9, 25, 26, 754, DateTimeKind.Local).AddTicks(1296), "Ford", "Brun", "Taunus", "PersonBil", 4 },
                    { "MyBike", new DateTime(2022, 7, 12, 8, 25, 26, 754, DateTimeKind.Local).AddTicks(1298), "Honda", "Svart", "XFusion", "MotorCykel", 4 },
                    { "oPq144", new DateTime(2022, 7, 12, 9, 23, 26, 754, DateTimeKind.Local).AddTicks(1293), "Tesla", "Silver", "Super", "PersonBil", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "abb456");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "abc123");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "krtekl");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "MyBike");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "RegNr",
                keyValue: "oPq144");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "Vehicles",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
