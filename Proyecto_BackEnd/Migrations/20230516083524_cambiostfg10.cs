using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class cambiostfg10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "note",
                table: "Users",
                type: "BINARY_FLOAT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "note",
                table: "Users",
                type: "BINARY_DOUBLE",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "BINARY_FLOAT",
                oldNullable: true);
        }
    }
}
