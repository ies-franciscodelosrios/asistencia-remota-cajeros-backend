using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CajeroModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ip = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ubication = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajeroModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CallModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    p2p = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    estado = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    iduser = table.Column<int>(name: "id_user", type: "NUMBER(10)", nullable: false),
                    userid = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    idcajero = table.Column<int>(name: "id_cajero", type: "NUMBER(10)", nullable: false),
                    cajeroid = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_CallModel_CajeroModel_cajeroid",
                        column: x => x.cajeroid,
                        principalTable: "CajeroModel",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CallModel_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallModel_cajeroid",
                table: "CallModel",
                column: "cajeroid");

            migrationBuilder.CreateIndex(
                name: "IX_CallModel_userid",
                table: "CallModel",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallModel");

            migrationBuilder.DropTable(
                name: "CajeroModel");
        }
    }
}
