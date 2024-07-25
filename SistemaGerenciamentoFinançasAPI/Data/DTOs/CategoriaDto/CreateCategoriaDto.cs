using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Data.DTOs.CategoriaDto
{
    public class CreateCategoriaDto
    {
        public string CategoriaNome { get; set; }
        public int OrcamentoCategoria { get; set; }
    }
}