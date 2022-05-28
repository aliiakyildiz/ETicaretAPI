using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductId",
                table: "Files");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductImageFileId",
                table: "Files",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProductImageFileId",
                table: "Files",
                column: "ProductImageFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Files_ProductImageFileId",
                table: "Files",
                column: "ProductImageFileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductId",
                table: "Files",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Files_ProductImageFileId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_ProductImageFileId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ProductImageFileId",
                table: "Files");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductId",
                table: "Files",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
