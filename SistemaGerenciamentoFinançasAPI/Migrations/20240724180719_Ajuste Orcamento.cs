using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGerenciamentoFinançasAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OrcamentoRestante",
                table: "Categorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrcamentoRestante",
                table: "Categorias");
        }
    }
}
