using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace senai_inlock_webAPI_CodeFirst.Migrations
{
    public partial class criacaobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estudios",
                columns: table => new
                {
                    idEstudio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEstudio = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudios", x => x.idEstudio);
                });

            migrationBuilder.CreateTable(
                name: "tipoUsuarios",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissao = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoUsuarios", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "jogos",
                columns: table => new
                {
                    idJogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeJogo = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "DATE", nullable: false),
                    valor = table.Column<decimal>(type: "DECIMAL (18,2)", nullable: false),
                    idEstudio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jogos", x => x.idJogo);
                    table.ForeignKey(
                        name: "FK_jogos_estudios_idEstudio",
                        column: x => x.idEstudio,
                        principalTable: "estudios",
                        principalColumn: "idEstudio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_usuarios_tipoUsuarios_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "tipoUsuarios",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "estudios",
                columns: new[] { "idEstudio", "nomeEstudio" },
                values: new object[,]
                {
                    { 1, "Blizzard" },
                    { 2, "Rockstar Studios" },
                    { 3, "Square Enix" }
                });

            migrationBuilder.InsertData(
                table: "tipoUsuarios",
                columns: new[] { "idTipoUsuario", "permissao" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "jogos",
                columns: new[] { "idJogo", "dataLancamento", "descricao", "idEstudio", "nomeJogo", "valor" },
                values: new object[,]
                {
                    { 1, new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "É um jogo que contém bastante ação...", 1, "Diablo 3", 99.00m },
                    { 2, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jogo eletrônico de ação-aventura western.", 1, "Red Dead Redemption II", 99.00m }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "senha" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", 1, "admin" },
                    { 2, "cliente@cliente.com", 2, "cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_jogos_idEstudio",
                table: "jogos",
                column: "idEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_email",
                table: "usuarios",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_idTipoUsuario",
                table: "usuarios",
                column: "idTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jogos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "estudios");

            migrationBuilder.DropTable(
                name: "tipoUsuarios");
        }
    }
}
