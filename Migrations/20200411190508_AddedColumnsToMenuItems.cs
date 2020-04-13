using Microsoft.EntityFrameworkCore.Migrations;

namespace FrancescosPizzeriaApi.Migrations
{
    public partial class AddedColumnsToMenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "MenuItem");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceReg",
                table: "MenuItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceSmall",
                table: "MenuItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SizeReg",
                table: "MenuItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeSmall",
                table: "MenuItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceReg",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "PriceSmall",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "SizeReg",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "SizeSmall",
                table: "MenuItem");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MenuItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
