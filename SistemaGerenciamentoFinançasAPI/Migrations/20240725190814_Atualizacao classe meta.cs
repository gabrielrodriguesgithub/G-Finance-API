using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGerenciamentoFinançasAPI.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacaoclassemeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrcamentoRestante",
                table: "Categorias");

            migrationBuilder.AddColumn<bool>(
                name: "Concluida",
                table: "Metas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluida",
                table: "Metas");

            migrationBuilder.AddColumn<double>(
                name: "OrcamentoRestante",
                table: "Categorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
