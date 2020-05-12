using Microsoft.EntityFrameworkCore.Migrations;

namespace FrancescosPizzeriaApi.Migrations
{
    public partial class djhbdbjqwd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_MenuItem_ItemId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_ItemId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "OrderItem");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceReg",
                table: "OrderItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceSmall",
                table: "OrderItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SizeReg",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeSmall",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequests",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "OrderItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "PriceReg",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "PriceSmall",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "SizeReg",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "SizeSmall",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "SpecialRequests",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemId",
                table: "OrderItem",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_MenuItem_ItemId",
                table: "OrderItem",
                column: "ItemId",
                principalTable: "MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
