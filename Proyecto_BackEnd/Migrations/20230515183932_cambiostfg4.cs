﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class cambiostfg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "duration",
                table: "Calls",
                type: "DECIMAL(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(3,2)",
                oldPrecision: 3,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "duration",
                table: "Calls",
                type: "DECIMAL(3,2)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }
    }
}
