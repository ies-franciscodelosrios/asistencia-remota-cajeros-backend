﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class cambiostfg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "Calls",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "Calls");

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "Users",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }
    }
}
