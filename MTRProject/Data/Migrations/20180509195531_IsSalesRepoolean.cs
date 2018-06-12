using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MTRProject.Data.Migrations
{
    public partial class IsSalesRepoolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_MTRUser_MTRUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_MTRUser_MTRUserId",
                table: "Sale");

            migrationBuilder.DropTable(
                name: "MTRUser");

            migrationBuilder.DropIndex(
                name: "IX_Sale_MTRUserId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Customer_MTRUserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MTRUserId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "MTRUserId",
                table: "Customer");

            migrationBuilder.AddColumn<bool>(
                name: "IsSalesRep",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSalesRep",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "MTRUserId",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MTRUserId",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MTRUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTRUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_MTRUserId",
                table: "Sale",
                column: "MTRUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_MTRUserId",
                table: "Customer",
                column: "MTRUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_MTRUser_MTRUserId",
                table: "Customer",
                column: "MTRUserId",
                principalTable: "MTRUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_MTRUser_MTRUserId",
                table: "Sale",
                column: "MTRUserId",
                principalTable: "MTRUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
