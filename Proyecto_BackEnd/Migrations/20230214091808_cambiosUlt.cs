using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class cambiosUlt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Users_UserId",
                table: "Calls");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Users_UserId",
                table: "Calls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Users_UserId",
                table: "Calls");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Users_UserId",
                table: "Calls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
