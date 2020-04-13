using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrancescosPizzeriaApi.Migrations
{
    public partial class AddedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClockedInAt",
                table: "TimeSheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockedOutAt",
                table: "TimeSheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OffBreakAt",
                table: "TimeSheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OnBreakAt",
                table: "TimeSheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClockedInAt",
                table: "TimeSheet");

            migrationBuilder.DropColumn(
                name: "ClockedOutAt",
                table: "TimeSheet");

            migrationBuilder.DropColumn(
                name: "OffBreakAt",
                table: "TimeSheet");

            migrationBuilder.DropColumn(
                name: "OnBreakAt",
                table: "TimeSheet");
        }
    }
}
