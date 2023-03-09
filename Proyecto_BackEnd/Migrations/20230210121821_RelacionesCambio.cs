using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class RelacionesCambio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Cashiers_cajeroid",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Users_userid",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_cajeroid",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_userid",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "cajeroid",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Calls");

            migrationBuilder.AlterColumn<int>(
                name: "id_user",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "id_cajero",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_id_cajero",
                table: "Calls",
                column: "id_cajero");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_id_user",
                table: "Calls",
                column: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Cashiers_id_cajero",
                table: "Calls",
                column: "id_cajero",
                principalTable: "Cashiers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Users_id_user",
                table: "Calls",
                column: "id_user",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Cashiers_id_cajero",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Users_id_user",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_id_cajero",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_id_user",
                table: "Calls");

            migrationBuilder.AlterColumn<int>(
                name: "id_user",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_cajero",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cajeroid",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calls_cajeroid",
                table: "Calls",
                column: "cajeroid");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_userid",
                table: "Calls",
                column: "userid");

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
    }
}
