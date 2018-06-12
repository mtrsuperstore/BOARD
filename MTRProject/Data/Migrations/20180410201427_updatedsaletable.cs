using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MTRProject.Data.Migrations
{
    public partial class updatedsaletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleID",
                table: "SalesRep",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesRepID",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesRep_SaleID",
                table: "SalesRep",
                column: "SaleID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRep_Sale_SaleID",
                table: "SalesRep",
                column: "SaleID",
                principalTable: "Sale",
                principalColumn: "SaleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRep_Sale_SaleID",
                table: "SalesRep");

            migrationBuilder.DropIndex(
                name: "IX_SalesRep_SaleID",
                table: "SalesRep");

            migrationBuilder.DropColumn(
                name: "SaleID",
                table: "SalesRep");

            migrationBuilder.DropColumn(
                name: "SalesRepID",
                table: "Sale");
        }
    }
}
