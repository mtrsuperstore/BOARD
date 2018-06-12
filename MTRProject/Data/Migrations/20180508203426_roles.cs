using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MTRProject.Data.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sale",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ApplicationUserId",
                table: "Sale",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ApplicationUserId",
                table: "Customer",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_ApplicationUserId",
                table: "Customer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AspNetUsers_ApplicationUserId",
                table: "Sale",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_ApplicationUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AspNetUsers_ApplicationUserId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_ApplicationUserId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ApplicationUserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
