using Microsoft.EntityFrameworkCore.Migrations;

namespace JiuFu.ORM.Migrations
{
    public partial class JiuFu003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderStatus",
                table: "GoodsOrders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OrderStatus",
                table: "CommodityOrders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "GoodsOrders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "CommodityOrders");
        }
    }
}
