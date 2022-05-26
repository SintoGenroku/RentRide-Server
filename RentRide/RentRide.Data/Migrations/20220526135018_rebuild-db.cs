using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentRide.Data.Migrations
{
    public partial class rebuilddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Cars_CarId",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_RenterId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RenterId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CarId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarModels");

            migrationBuilder.AddColumn<Guid>(
                name: "CarModelId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "RenterId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "CarModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RenterId",
                table: "Cars",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarId",
                table: "CarModels",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Cars_CarId",
                table: "CarModels",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_RenterId",
                table: "Cars",
                column: "RenterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
