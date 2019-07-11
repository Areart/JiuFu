using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JiuFu.ORM.Migrations
{
    public partial class JiuFu002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Laundry",
                table: "LaundryOrders");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "LaundryOrders",
                newName: "State");

            migrationBuilder.AddColumn<Guid>(
                name: "LaundryId",
                table: "LaundryOrders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OrderStatus",
                table: "FoodOrders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_LaundryOrders_LaundryId",
                table: "LaundryOrders",
                column: "LaundryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaundryOrders_Laundrys_LaundryId",
                table: "LaundryOrders",
                column: "LaundryId",
                principalTable: "Laundrys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaundryOrders_Laundrys_LaundryId",
                table: "LaundryOrders");

            migrationBuilder.DropIndex(
                name: "IX_LaundryOrders_LaundryId",
                table: "LaundryOrders");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "LaundryOrders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "FoodOrders");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "LaundryOrders",
                newName: "state");

            migrationBuilder.AddColumn<string>(
                name: "Laundry",
                table: "LaundryOrders",
                nullable: true);
        }
    }
}
