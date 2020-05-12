using Microsoft.EntityFrameworkCore.Migrations;

namespace FrancescosPizzeriaApi.Migrations
{
    public partial class EditedTablesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Order_OrderId",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_OrderId",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MenuItem");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderType",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointsEarned",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequests",
                table: "MenuItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PointsEarned",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SpecialRequests",
                table: "MenuItem");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MenuItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_OrderId",
                table: "MenuItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Order_OrderId",
                table: "MenuItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
