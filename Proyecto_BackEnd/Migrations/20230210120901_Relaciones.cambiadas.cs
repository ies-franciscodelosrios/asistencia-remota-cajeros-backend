using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Relacionescambiadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallModel_CajeroModel_cajeroid",
                table: "CallModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CallModel_Users_userid",
                table: "CallModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CallModel",
                table: "CallModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CajeroModel",
                table: "CajeroModel");

            migrationBuilder.RenameTable(
                name: "CallModel",
                newName: "Calls");

            migrationBuilder.RenameTable(
                name: "CajeroModel",
                newName: "Cashiers");

            migrationBuilder.RenameIndex(
                name: "IX_CallModel_userid",
                table: "Calls",
                newName: "IX_Calls_userid");

            migrationBuilder.RenameIndex(
                name: "IX_CallModel_cajeroid",
                table: "Calls",
                newName: "IX_Calls_cajeroid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calls",
                table: "Calls",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cashiers",
                table: "Cashiers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Cashiers_cajeroid",
                table: "Calls",
                column: "cajeroid",
                principalTable: "Cashiers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Users_userid",
                table: "Calls",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Cashiers_cajeroid",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Users_userid",
                table: "Calls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cashiers",
                table: "Cashiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calls",
                table: "Calls");

            migrationBuilder.RenameTable(
                name: "Cashiers",
                newName: "CajeroModel");

            migrationBuilder.RenameTable(
                name: "Calls",
                newName: "CallModel");

            migrationBuilder.RenameIndex(
                name: "IX_Calls_userid",
                table: "CallModel",
                newName: "IX_CallModel_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Calls_cajeroid",
                table: "CallModel",
                newName: "IX_CallModel_cajeroid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CajeroModel",
                table: "CajeroModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CallModel",
                table: "CallModel",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallModel_CajeroModel_cajeroid",
                table: "CallModel",
                column: "cajeroid",
                principalTable: "CajeroModel",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallModel_Users_userid",
                table: "CallModel",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
