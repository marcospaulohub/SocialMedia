using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PerfilMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    NomeExibicao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sobre = table.Column<string>(type: "varchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "varchar(20)", nullable: false),
                    Profissao = table.Column<string>(type: "varchar(150)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfil_Conta_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_IdConta",
                table: "Perfil",
                column: "IdConta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
