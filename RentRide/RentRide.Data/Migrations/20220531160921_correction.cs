using Microsoft.EntityFrameworkCore.Migrations;

namespace RentRide.Data.Migrations
{
    public partial class correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Salons_SalonId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Cars_CarId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Salons_SalonId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Users_ClientId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salons",
                table: "Salons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Salons",
                newName: "Salon");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Contract");

            migrationBuilder.RenameTable(
                name: "CarModels",
                newName: "CarModel");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_SalonId",
                table: "Contract",
                newName: "IX_Contract_SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ClientId",
                table: "Contract",
                newName: "IX_Contract_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_CarId",
                table: "Contract",
                newName: "IX_Contract_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salon",
                table: "Salon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModel_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Salon_SalonId",
                table: "Cars",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Cars_CarId",
                table: "Contract",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Salon_SalonId",
                table: "Contract",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_User_ClientId",
                table: "Contract",
                column: "ClientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModel_CarModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Salon_SalonId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Cars_CarId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Salon_SalonId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_User_ClientId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salon",
                table: "Salon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Salon",
                newName: "Salons");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "Contracts");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "CarModels");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_SalonId",
                table: "Contracts",
                newName: "IX_Contracts_SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_ClientId",
                table: "Contracts",
                newName: "IX_Contracts_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_CarId",
                table: "Contracts",
                newName: "IX_Contracts_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salons",
                table: "Salons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Salons_SalonId",
                table: "Cars",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Cars_CarId",
                table: "Contracts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Salons_SalonId",
                table: "Contracts",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Users_ClientId",
                table: "Contracts",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
