using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MTRProject.Data.Migrations
{
    public partial class updatedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesRep");

            migrationBuilder.DropColumn(
                name: "SalesRepID",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "SalesRepID",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "MTRUserId",
                table: "Sale",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MTRUserId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MTRUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SalesRepID",
                table: "Sale",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesRepID",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SalesRep",
                columns: table => new
                {
                    SalesRepID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SaleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRep", x => x.SalesRepID);
                    table.ForeignKey(
                        name: "FK_SalesRep_Sale_SaleID",
                        column: x => x.SaleID,
                        principalTable: "Sale",
                        principalColumn: "SaleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRep_SaleID",
                table: "SalesRep",
                column: "SaleID");
        }
    }
}
