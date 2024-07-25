using SistemaGerenciamentoFinançasAPI.Data.DTOs.DespesasDto;
using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Data.DTOs.CategoriaDto
{
    public class ReadCategoriaDto
    {
        public int Id { get; set; }
        public virtual List<ReadDespesaDto> Despesas { get; set; }
        public string CategoriaNome { get; set; }
        public int OrcamentoCategoria { get; set; }
        public double OrcamentoRestante { get; set; }
    }
}

