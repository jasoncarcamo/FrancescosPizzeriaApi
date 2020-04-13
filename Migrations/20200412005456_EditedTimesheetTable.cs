using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrancescosPizzeriaApi.Migrations
{
    public partial class EditedTimesheetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimeSheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "HadBreak",
                table: "TimeSheet",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimeSheet");

            migrationBuilder.DropColumn(
                name: "HadBreak",
                table: "TimeSheet");
        }
    }
}
