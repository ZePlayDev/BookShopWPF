using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopWPF.Migrations
{
    /// <inheritdoc />
    public partial class meow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Administrators");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryID",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID1",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID1",
                table: "Products",
                column: "CategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID1",
                table: "Products",
                column: "CategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryID1",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Managers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Managers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Managers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<int>>(
                name: "Product",
                table: "Clients",
                type: "integer[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Administrators",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Administrators",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Administrators",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
