using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class cambiosRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "id_cajero",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "id_user",
                table: "Calls");

            migrationBuilder.AddColumn<int>(
                name: "CajeroId",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CajeroId",
                table: "Calls",
                column: "CajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_UserId",
                table: "Calls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Cashiers_CajeroId",
                table: "Calls",
                column: "CajeroId",
                principalTable: "Cashiers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Users_UserId",
                table: "Calls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Cashiers_CajeroId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Users_UserId",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_CajeroId",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_UserId",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "CajeroId",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Calls");

            migrationBuilder.AddColumn<int>(
                name: "id_cajero",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_user",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: true);

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
    }
}
